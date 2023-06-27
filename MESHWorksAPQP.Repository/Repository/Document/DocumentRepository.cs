//// <copyright file="DocumentRepository.cs" company="MESHWorksAPQP">
//// Copyright (c) MESHWorksAPQP. All rights reserved.
//// </copyright>

//namespace MESHWorksAPQP.Repository.Repository.Document
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Linq.Expressions;
//    using System.Text;
//    using System.Threading.Tasks;
//    using MESHWorksAPQP.Model.Models.Documents;
//    using MESHWorksAPQP.Repository.Context;
//    using MESHWorksAPQP.Repository.Interfaces;
//    using MESHWorksAPQP.Repository.Interfaces.Document;
//    using MESHWorksAPQP.Shared.Interface;

//    /// <summary>
//    /// Class DocumentRepository.
//    /// </summary>
//    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="DocumentRepository"/> class.
//        /// </summary>
//        /// <param name="dbContext">The database context.</param>
//        /// <param name="userIdentity">The user identity.</param>
//        public DocumentRepository(ApplicationDbContext dbContext)
//            : base(dbContext)
//        {
//        }

//        public void Create(Document entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Document> FirstOrDefaultAsync(Expression<Func<Document, bool>> filter)
//        {
//            throw new NotImplementedException();
//        }

//        public IQueryable<Document> GetAll(Expression<Func<Document, bool>> filter = null)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> GetExists(Expression<Func<Document, bool>> filter)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Document entity)
//        {
//            throw new NotImplementedException();
//        }

//        Task<Document> IGenericRepository<Document>.GetByIdAsync(Guid id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
