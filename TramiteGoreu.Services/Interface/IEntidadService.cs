namespace Goreu.Tramite.Services.Interface
{
    public interface IEntidadService : IServiceBase<EntidadRequestDto, EntidadResponseDto>
    {
        Task<BaseResponseGeneric<ICollection<EntidadResponseDto>>> GetAsync(string? descripcion, PaginationDto pagination);
    }
}
