using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Entities.info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Services.Interface
{
    public interface IAplicacionService
    {
        Task<BaseResponseGeneric<int>> AddAsync(AplicacionRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> UpdateAsync(int id, AplicacionRequestDto request);
        Task<BaseResponseGeneric<ICollection<AplicacionResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<AplicacionResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<ICollection<AplicacionInfo>>> GetAsync(string? descripcion);
        Task<BaseResponse> FinalizedAsync(int id);
        Task<BaseResponse> InitializedAsync(int id);
    }
}
