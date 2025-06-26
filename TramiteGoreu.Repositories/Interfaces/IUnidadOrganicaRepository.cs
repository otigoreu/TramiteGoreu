namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IUnidadOrganicaRepository : IRepositoryBase<UnidadOrganica>
    {
        Task<ICollection<UnidadOrganica>> GetAsync<TKey>(Expression<Func<UnidadOrganica, bool>> predicate, Expression<Func<UnidadOrganica, TKey>> orderBy, PaginationDto pagination);
    }
}
