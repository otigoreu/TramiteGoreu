namespace Goreu.Tramite.Services.Interface
{
    public interface IEntidadService
    {
        Task<BaseResponseGeneric<int>> AddAsync(EntidadRequestDto request);
        Task<BaseResponse> UpdateAsync(int id, EntidadRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> FinalizeAsync(int id);
        Task<BaseResponse> InitializeAsync(int id);
        Task<BaseResponseGeneric<EntidadResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<ICollection<EntidadResponseDto>>> GetAsync(string? descripcion, PaginationDto pagination);
    }
}
