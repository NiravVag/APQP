// <copyright file="EmailNotificationManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Setup.EmailNotification
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Command.Setup.EmailNotification;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.EmailNotification;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;

    /// <summary>
    /// Class EmailNotificationManager.
    /// </summary>
    public class EmailNotificationManager : SetupBaseManager<EmailNotification, SearchEmailNotificationCommand, EmailNotificationListVM, GetEmailNotificationCommand, EmailNotificationVM, SaveEmailNotificationCommand, EmailNotificationVM, EmailNotificationFilterVM>, IEmailNotificationManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ISetupRepositoty<EmailNotification> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotificationManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        public EmailNotificationManager(
            IMapper mapper,
            ISetupRepositoty<EmailNotification> repository)
             : base(mapper, repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Filters the data.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="query">The query.</param>
        /// <returns>
        /// IQueryable TEntity.
        /// </returns>
        protected override IQueryable<EmailNotification> FilterData(SearchEmailNotificationCommand command, IQueryable<EmailNotification> query)
        {
            if (!string.IsNullOrWhiteSpace(command?.Filter?.Code))
            {
                query = query.Where(x => x.CompanyType == command.Filter.CompanyType && x.Code == command.Filter.Code);
            }
            else
            {
                query = query.Where(x => x.CompanyType == command.Filter.CompanyType);
            }

            query = base.FilterData(command, query);

            return query;
        }
    }
}
