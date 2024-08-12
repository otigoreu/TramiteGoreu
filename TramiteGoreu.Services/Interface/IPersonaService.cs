using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;
using TramiteGoreu.Entities.info;

namespace TramiteGoreu.Services.Interface
{
    public interface IPersonaService
    {
        Task<BaseResponseGeneric<ICollection<PersonaInfo>>> GetAsync(string? nombres, PaginationDto pagination);
        Task<BaseResponseGeneric<PersonaResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(PersonaRequestDto resquest);
        Task<BaseResponse> UpdateAsync(int id, PersonaRequestDto resquest);
        Task<BaseResponse> DeleteAsync(int i);
        Task<BaseResponse> FinalizedAsync(int id);

    }
}
