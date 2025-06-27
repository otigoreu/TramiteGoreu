namespace Goreu.Tramite.Services.Interface
{
    public interface IAplicacionService : IServiceBase<AplicacionRequestDto, AplicacionResponseDto>
    {
        Task<BaseResponseGeneric<ICollection<AplicacionResponseDto>>> GetAsync(string? descripcion, PaginationDto pagination);
    }
}
