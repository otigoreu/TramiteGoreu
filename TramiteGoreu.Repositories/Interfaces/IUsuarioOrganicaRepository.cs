namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IUsuarioUnidadOrganicaRepository : IRepositoryBase<UsuarioUnidadOrganica>
    {
        Task<ICollection<UsuarioUnidadOrganica>> GetAsync<TKey>(Expression<Func<UsuarioUnidadOrganica, bool>> predicate, Expression<Func<UsuarioUnidadOrganica, TKey>> orderBy, PaginationDto pagination);
    }
}
