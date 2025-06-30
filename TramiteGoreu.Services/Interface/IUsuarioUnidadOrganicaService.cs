namespace Goreu.Tramite.Services.Interface
{
    public interface IUsuarioUnidadOrganicaService : IServiceBase<UsuarioUnidadOrganicaRequestDto, UsuarioUnidadOrganicaResponseDto>
    {
        Task<BaseResponseGeneric<ICollection<UsuarioUnidadOrganicaResponseDto>>> GetAsync(int idUnidadOrganica, PaginationDto pagination);
    }
}

