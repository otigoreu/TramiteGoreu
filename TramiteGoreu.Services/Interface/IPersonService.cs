using System.Linq.Expressions;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;
using TramiteGoreu.Entities.info;

namespace TramiteGoreu.Services.Interface
{
    public interface IPersonService
    {
        Task<BaseResponseGeneric<ICollection<PersonInfo>>> GetAsync(string? nombres);
        Task<BaseResponseGeneric<PersonResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(PersonRequestDto resquest);
        Task<BaseResponse> UpdateAsync(int id, PersonRequestDto resquest);
        Task<BaseResponse> DeleteAsync(int i);
        Task<BaseResponse> FinalizedAsync(int id);

    }
}
