namespace Goreu.Tramite.Services.Interface
{
    public interface IEntidadAplicacionService
    {
        Task<BaseResponseGeneric<int>> AddAsync(EntidadAplicacionRequestDto request);
        Task<BaseResponse> UpdateAsync(int id, EntidadAplicacionRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> FinalizeAsync(int id);
        Task<BaseResponse> InitializeAsync(int id);
        Task<BaseResponseGeneric<EntidadAplicacionResponseDto>> GetAsync(int id);
        //Task<BaseResponseGeneric<ICollection<EntidadAplicacionResponseDto>>> GetAsync(string? descripcion, PaginationDto pagination);
    }
}
