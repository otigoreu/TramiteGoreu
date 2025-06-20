using System.Linq.Expressions;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<ICollection<TEntity>> GetAsync();
        Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> GetAsync<Tkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Tkey>> orderBy);
        Task<TEntity?> GetAsync(int id);
        Task<int> AddAsync(TEntity entity);
        Task UpdateAsync();
        Task DeleteAsync(int id);
    }
}