using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using AbpBasic.DB2.ACTS;
using AbpBasic.DB2.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AbpBasic.DB2.EntityFrameworkCore.Repositories
{

    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class DB2RepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<DB2DbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public abstract string GetIdName();

        protected DB2RepositoryBase(IDbContextProvider<DB2DbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Add your common methods for all repositories
        protected Expression<Func<TEntity, bool>> CreateDB2EqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, GetIdName()),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        public override async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await GetAll().FirstOrDefaultAsync(CreateDB2EqualityExpressionForId(id));
        }

        public override TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().FirstOrDefault(CreateDB2EqualityExpressionForId(id));
        }
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="AbpBasicRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class DB2RepositoryBase<TEntity> : DB2RepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected DB2RepositoryBase(IDbContextProvider<DB2DbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }

    public class ACTRepository : DB2RepositoryBase<ACT, short>
    {
        protected ACTRepository(IDbContextProvider<DB2DbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public override string GetIdName()
        {
            return "ACTNO";
        }
    }


}
