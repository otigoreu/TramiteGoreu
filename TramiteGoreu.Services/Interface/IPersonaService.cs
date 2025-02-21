using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using TramiteGoreu.Entities.info;

namespace Goreu.Tramite.Services.Interface
{
    public interface IPersonaService
    {
        Task<BaseResponseGeneric<ICollection<PersonaInfo>>> GetAsync(string? nombres, PaginationDto pagination);
        Task<BaseResponseGeneric<ICollection<PersonaInfo>>> GetAsyncfilter(string? nombres, PaginationDto pagination);
        Task<BaseResponseGeneric<PersonaInfo>> GetAsyncBYEmail(string email);
        Task<BaseResponseGeneric<PersonaResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(PersonaRequestDto resquest);
        Task<BaseResponse> UpdateAsync(int id, PersonaRequestDto resquest);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> FinalizedAsync(int id);
        Task<BaseResponse> InitializedAsync(int id);

    }
}
