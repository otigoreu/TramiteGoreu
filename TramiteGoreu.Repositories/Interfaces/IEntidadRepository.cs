namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IEntidadRepository : IRepositoryBase<Entidad>
    {
        Task<ICollection<Entidad>> GetAsync<TKey>(Expression<Func<Entidad, bool>> predicate, Expression<Func<Entidad, TKey>> orderBy, PaginationDto pagination);
    }
}
