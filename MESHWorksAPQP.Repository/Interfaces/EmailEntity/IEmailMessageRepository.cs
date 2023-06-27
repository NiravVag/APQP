// <copyright file="IEmailMessageRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.Email
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Email;

    /// <summary>
    /// Interface IEmailMessageRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.IGenericRepository{MESHWorksAPQP.Model.Models.Email.EmailMessage}" />
    public interface IEmailMessageRepository : IGenericRepository<EmailMessage>
    {
    }
}
