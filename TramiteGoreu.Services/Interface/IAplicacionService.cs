namespace Goreu.Tramite.Services.Interface
{
    public interface IAplicacionService
    {
        Task<BaseResponseGeneric<int>> AddAsync(AplicacionRequestDto request);
        Task<BaseResponse> UpdateAsync(int id, AplicacionRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> FinalizeAsync(int id);
        Task<BaseResponse> InitializeAsync(int id);
        Task<BaseResponseGeneric<AplicacionResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<ICollection<AplicacionResponseDto>>> GetAsync(string? descripcion, PaginationDto pagination);
    }
}
