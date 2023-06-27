// <copyright file="JsonExceptionMiddleware.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Middlewares
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class JsonExceptionMiddleware.
    /// </summary>
    public sealed class JsonExceptionMiddleware
    {
        /// <summary>
        /// The default error message
        /// </summary>
        public const string DefaultErrorMessage = "A server error occurred.";

        /// <summary>
        /// The env.
        /// </summary>
        private readonly IWebHostEnvironment env;

        /// <summary>
        /// The serializer.
        /// </summary>
        private readonly JsonSerializer serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        public JsonExceptionMiddleware(IWebHostEnvironment env)
        {
            this.env = env;

            this.serializer = new JsonSerializer();
            this.serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null)
            {
                return;
            }

            if (ex is ValidationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            // context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
            // context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
            var error = new string[] { ex.Message };

            using (var writer = new StreamWriter(context.Response.Body))
            {
                this.serializer.Serialize(writer, error);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}
