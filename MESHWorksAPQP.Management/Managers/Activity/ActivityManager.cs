// <copyright file="ActivityManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Activity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Command.Activity;
    using MESHWorksAPQP.Management.Interface.Managers.Activity;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Activity;
    using MESHWorksAPQP.Model.Models.Activity;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Shared.Enum;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class ActivityManager
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Managers.Activity.IActivityManager" />
    public class ActivityManager : IActivityManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IGenericRepository<Activity> repository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityManager" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ActivityManager(IGenericRepository<Activity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Saves the activity.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">Invalid Request.</exception>
        public async Task<ActivityVM> SaveActivity(ActivityVM input)
        {
            if (input != null)
            {
                Activity activity = this.mapper.Map<Activity>(input);
                this.repository.Create(activity);
                await this.repository.SaveAsync();
                return input;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// A <see cref="Task" /> representing the asynchronous operation.
        /// </returns>
        public async Task<Page<ActivityListVM>> GetActivity(GetActivityCommand command)
        {
            var query = this.repository.GetAll(x => x.EntityId == command.Filter.EntityId);

            if (command.Filter.ChildEntityId.HasValue && command.Filter.ChildEntityId != Guid.Empty)
            {
                query = query.Where(x => x.ChildEntityId == command.Filter.ChildEntityId);
            }

            if (command.Filter.ReferenceId.HasValue && command.Filter.ReferenceId != Guid.Empty)
            {
                query = query.Where(x => x.ReferenceId == command.Filter.ReferenceId);
            }

            var size = query.Count();
            var limit = command.Filter.PagingOption?.Limit ?? (size == 0 ? 1 : size);
            var skip = (command.Filter.PagingOption?.Offset ?? 0) * limit;

            var activities = await query
               .Skip(skip)
               .Take(limit)
               .ProjectTo<ActivityListVM>(this.mapper.ConfigurationProvider).ToListAsync();

            return new Page<ActivityListVM>()
            {
                Items = activities,
                TotalSize = size
            };
        }
    }
}
