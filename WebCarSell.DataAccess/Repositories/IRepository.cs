using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.DataAccess.Interfaces;

namespace WEBCarSell.DataAccess.Repositories
{
    public interface IRepository
    {

        Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class;

        Task<TEntity> GetById<TEntity>(Guid? id) where TEntity : class;

        Task<TEntity> Create<TEntity>(TEntity entity) where TEntity : class;

        Task Update<TEntity>(TEntity entity) where TEntity : class;

        Task Delete<TEntity>(TEntity entity) where TEntity : ISoftDeletable;

        Task HardDelete<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> IfExist<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        Task<IEnumerable<TEntity>> GetWhere<TEntity>(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        where TEntity : class;
    }
}
