// <copyright file="Startup.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP
{
    using System;
    using System.Reflection;
    using AutoMapper;
    using EmailProvider.Extensions;
    using MESHWorksAPQP.Management.Extensions;
    using MESHWorksAPQP.Management.Helpers;
    using MESHWorksAPQP.Management.Interface.Helpers;
    using MESHWorksAPQP.Management.Interface.Settings;
    using MESHWorksAPQP.Management.Settings;
    using MESHWorksAPQP.Middlewares;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Shared.Interface;
    using MESHWorksAPQP.Shared.Service;
    using MESHWorksAPQP.Shared.Settings;
    using Microsoft.ApplicationInsights.AspNetCore.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using SimpleInjector;
    using SimpleInjector.Integration.AspNetCore.Mvc;
    using SimpleInjector.Lifestyles;
    using StorageManager.Extensions;

    /// <summary>
    /// Class Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly Container container = new SimpleInjector.Container();

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="env">The env.</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.Configuration = configuration;

            this.WebHostEnvironment = env;

            this.SetupLogging(env);
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets the web host environment.
        /// </summary>
        /// <value>
        /// The web host environment.
        /// </value>
        public IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            // Add application insights
            var appInsightsSettings = this.Configuration.GetSection("ApplicationInsights").Get<ApplicationInsightsSettings>();
            var appInsights = this.Configuration.GetSection("ApplicationInsights");
            var aiOptions = new ApplicationInsightsServiceOptions()
            {
                InstrumentationKey = appInsights["InstrumentationKey"],
            };
            services.AddApplicationInsightsTelemetry(aiOptions);
            services.AddScoped<IUserIdentity, UserIdentity>();

            string connectionString = this.Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString).UseLazyLoadingProxies());

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddAuthentication("Bearer")
              .AddJwtBearer("Bearer", config =>
              {
                  config.Authority = this.Configuration.GetValue<string>("Authentication:Authority");
                  config.Audience = "meshAPQP.api";
                  config.RequireHttpsMetadata = false;
              });

            services.AddCors();
            services.AddTransient<IAuthenticationHelper, AuthenticationHelper>();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            });

            services.AddControllersWithViews();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            this.container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            services.AddHttpContextAccessor();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(this.container));

            // services.AddTransient(c => this.container.GetInstance<IAuthenticationHelper>());
            // services.AddSingleton<IApplicationInsightsSettings>(appInsightsSettings);
            services.AddDbContext<ApplicationDbContext>();

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(this.Configuration.GetSection("Logging"));
                builder.AddConsole();
                builder.AddDebug();
            });

            services.AddSimpleInjector(this.container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation()
                    .AddViewComponentActivation()
                    .AddPageModelActivation()
                    .AddTagHelperActivation();

                options.AutoCrossWireFrameworkComponents = true;
            });

            services.UseSimpleInjectorAspNetRequestScoping(this.container);

            var config = Management.Mappings.AutoMapperConfig.RegisterMappings();
            this.container.RegisterInstance<MapperConfiguration>(config);
            this.container.Register<IMapper>(() => config.CreateMapper(this.container.GetInstance));

            // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(this.Configuration.GetValue<string>("Syncfusion:Key"));
            this.InitializeContainer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MESHWorksAPQP", Version = "v1" });
            });
        }

        /// <summary>
        /// Configures the specified application. This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MESHWorksAPQP v1"));
            }

            app.UseHttpsRedirection();

            // this.container.Register<IAuthenticationHelper, AuthenticationHelper>();
            this.container.RegisterInstance(app.ApplicationServices.GetService<IServiceProvider>());
            this.container.RegisterInstance(this.Configuration);

            app.UseSimpleInjector(this.container);
            app.UseMiddleware<LoggedInUserInfoMiddleware>();
            var jsonExceptionMiddleware = new JsonExceptionMiddleware(
     app.ApplicationServices.GetRequiredService<IWebHostEnvironment>());
            app.UseExceptionHandler(new ExceptionHandlerOptions { ExceptionHandler = jsonExceptionMiddleware.Invoke });

            app.UseRouting();

            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true) // allow any origin
              .AllowCredentials()); // allow credentials

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            this.container.Verify();
        }

        /// <summary>
        /// Initializes the container.
        /// </summary>
        private void InitializeContainer()
        {
            this.container.RegisterInstance<IAppSettings>(this.Configuration.GetSection("AppSettings").Get<AppSettings>());

            // this.container.Register<IProfileService, ProfileService>(Lifestyle.Transient);
            this.container.RegisterManagementService(this.Configuration);
            this.container.RegisterRepositoryService(this.Configuration);

            this.container.Register<IUserIdentity, UserIdentity>(Lifestyle.Transient);
            this.container.RegisterEmailProviderService(this.Configuration);
            this.container.RegisterStorageManagerService(this.Configuration);
        }

        /// <summary>
        /// Setups the logging.
        /// </summary>
        /// <param name="env">The env.</param>
        private void SetupLogging(IWebHostEnvironment env)
        {
            var logFilePath = this.Configuration.GetValue<string>("AppSettings:LogFilePath");
            var appInsightsKey = this.Configuration.GetValue<string>("AppSettings:ApplicationInsights:InstrumentationKey");

            // Log.Logger = new LoggerConfiguration()
            //    .Enrich.FromLogContext()
            //    .MinimumLevel.Debug()
            //    .Enrich.WithMachineName()
            //    .WriteTo.ApplicationInsights(appInsightsKey, TelemetryConverter.Traces, LogEventLevel.Warning)
            //    .WriteTo.RollingFile(
            //        Path.Combine(env.ContentRootPath, logFilePath),
            //        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {MachineName} {Message}{NewLine}{Exception}").CreateLogger();
        }
    }
}
