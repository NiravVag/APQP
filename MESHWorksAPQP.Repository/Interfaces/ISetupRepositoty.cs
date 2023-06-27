// <copyright file="ISetupRepositoty.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Interface;

    /// <summary>
    /// Interface ISetupRepositoty.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.IGenericRepository{TEntity}" />
    public interface ISetupRepositoty<TEntity> : IGenericRepository<TEntity>
        where TEntity : ISetupBaseEntity
    {
    }
}
