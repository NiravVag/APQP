// <copyright file="UserManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.User;
    using MESHWorksAPQP.Management.Interface.Managers.User;
    using MESHWorksAPQP.Management.Interface.Settings;
    using MESHWorksAPQP.Management.ViewModel.User;
    using MESHWorksAPQP.Model.Models.Role;
    using MESHWorksAPQP.Repository.CustomModel;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.User;
    using MESHWorksAPQP.Shared.Interface;
    using Newtonsoft.Json;

    /// <summary>
    /// Class UserManager.
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// The application settings.
        /// </summary>
        private readonly IAppSettings appSettings;

        /// <summary>
        /// The user role repository
        /// </summary>
        private readonly IGenericRepository<UserRole> userRoleRepository;

        /// <summary>
        /// The user role repository
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="userRoleRepository">The user role repository.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="userIdentity">The user identity.</param>
        public UserManager(
          IAppSettings appSettings,
          IGenericRepository<UserRole> userRoleRepository,
          IUserRepository userRepository,
          IUserIdentity userIdentity)
        {
            this.appSettings = appSettings;
            this.userRoleRepository = userRoleRepository;
            this.userRepository = userRepository;
            this.userIdentity = userIdentity;
        }

        /// <summary>
        /// Gets the user menu.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of MenuVM.
        /// </returns>
        public async Task<List<MenuVM>> GetUserMenu(GetUserMenuCommand command)
        {
            List<MenuVM> menus = null;
            if (this.userIdentity?.UserInfo != null)
            {
                var menuResponse = await this.userRepository.GetUserMenu(this.userIdentity.UserInfo.CompanyId, this.userIdentity.UserInfo.Id);

                menus = new List<MenuVM>();
                foreach (var menuItem in menuResponse.Where(x => x.ParentId == null))
                {
                    var menuChildren = new List<MenuVM>();
                    var subMenus = menuResponse.Where(x => x.ParentId == menuItem.Id);
                    foreach (var subMenuItem in subMenus)
                    {
                        menuChildren.Add(new MenuVM
                        {
                            Type = "link",
                            Label = subMenuItem.Name,
                            Route = subMenuItem.PageUrl,
                        });
                    }

                    menus.Add(new MenuVM
                    {
                        Type = subMenus.Any() ? "dropdown" : "link",
                        Label = menuItem.Name,
                        Route = menuItem.PageUrl,
                        Icon = menuItem.MenuIcon,
                        Children = menuChildren,
                    });
                }
            }

            return menus;
        }

        /// <summary>
        /// Gets the user permission.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of PermissionDetail.
        /// </returns>
        public async Task<IList<PermissionDetail>> GetUserPermissions(GetPermissionCommand command)
        {
            var permissionResponse = await this.userRepository.GetUserPermissions(this.userIdentity.UserInfo.CompanyId, this.userIdentity.UserInfo.Id);
            return permissionResponse;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>User</returns>
        public async Task<UserVM> GetUser(GetUserCommand command)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri(this.appSettings.MeshPortalApiBaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync($"{this.appSettings.MeshPortalApiBaseUrl}/user/{command.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<UserVM>(responseString);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of User</returns>
        public async Task<List<UserVM>> GetUserList(GetUsersCommand command)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri(this.appSettings.MeshPortalApiBaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync($"{this.appSettings.MeshPortalApiBaseUrl}/user/search/{command.CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        List<UserVM> users = JsonConvert.DeserializeObject<List<UserVM>>(responseString);

                        if (users != null && users.Any())
                        {
                            foreach (var item in users)
                            {
                                var userRole = await this.userRoleRepository.FirstOrDefaultAsync(x => x.UserId == item.Id && !x.IsDeleted);

                                if (userRole != null)
                                {
                                    item.RoleId = userRole.RoleId;
                                }
                            }
                        }

                        return users;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
