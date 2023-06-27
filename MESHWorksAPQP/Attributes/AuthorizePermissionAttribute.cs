// <copyright file="AuthorizePermissionAttribute.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Attributes
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using MESHWorksAPQP.Shared.Enum;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Class AuthorizePermissionAttribute.
    /// </summary>
    public class AuthorizePermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizePermissionAttribute"/> class.
        /// </summary>
        /// <param name="code">The code</param>
        /// <param name="permission">The permission.</param>
        public AuthorizePermissionAttribute(PermissionCode code, PermissionType permission)
        {
            this.Code = code;
            this.Permission = permission;
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private PermissionCode Code { get; set; }

        /// <summary>
        /// Gets or sets the permission.
        /// </summary>
        /// <value>
        /// The permission.
        /// </value>
        private PermissionType Permission { get; set; }

        /// <inheritdoc/>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var obj = (ControllerActionDescriptor)context.ActionDescriptor;
            var controllerName = obj.ControllerName;

            if (context.HttpContext.User == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // this.UserRepository = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
            string id = context.HttpContext.User.FindFirstValue("sub");
            if (Code == PermissionCode.Setup)
            {
                Code = Enum.Parse<PermissionCode>(Code + "_" + controllerName);
            }

            //var userData = null;// this.UserRepository.GetUserPermissionByCode(id, Code.ToString()).Result;

            //if (userData.Any())
            //{
            //    if (Permission == PermissionType.View && !userData.FirstOrDefault().HasView)
            //    {
            //        context.Result = new UnauthorizedResult();
            //    }
            //    else if (Permission == PermissionType.AddEdit && !userData.FirstOrDefault().HasAddEdit)
            //    {
            //        context.Result = new UnauthorizedResult();
            //    }
            //    else if (Permission == PermissionType.Delete && !userData.FirstOrDefault().HasDelete)
            //    {
            //        context.Result = new UnauthorizedResult();
            //    }
            //}
            //else
            //{
            //    context.Result = new UnauthorizedResult();
            //}
        }
    }
}
