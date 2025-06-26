namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IAplicacionRepository : IRepositoryBase<Aplicacion>
    {
        Task<ICollection<Aplicacion>> GetAsync<TKey>(Expression<Func<Aplicacion, bool>> predicate, Expression<Func<Aplicacion, TKey>> orderBy, PaginationDto pagination);
    }
}
