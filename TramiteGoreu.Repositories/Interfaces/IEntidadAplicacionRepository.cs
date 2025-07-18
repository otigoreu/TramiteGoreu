namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IEntidadAplicacionRepository : IRepositoryBase<EntidadAplicacion>
    {
        Task<ICollection<EntidadAplicacion>> GetAsync<TKey>(Expression<Func<EntidadAplicacion, bool>> predicate, Expression<Func<EntidadAplicacion, TKey>> orderBy, PaginationDto pagination);

        Task<EntidadAplicacion> GetAsync(int idEntidad, int idAplicacion);
    }
}
