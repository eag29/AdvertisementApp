using EmirAliGirgin.AdvertisementApp2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.DAL.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.Desc);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.Desc);
        Task<T> FindByAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asnotracking = false);
        IQueryable<T> GetQuery();
        Task CreateAsync(T entity);
        void Remove(T entity);
        void Update(T entity, T unchanged);
    }
}
