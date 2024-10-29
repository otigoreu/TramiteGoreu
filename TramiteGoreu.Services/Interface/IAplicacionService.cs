using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;

namespace TramiteGoreu.Services.Interface
{
    public  interface IAplicacionService
    {
        Task <BaseResponseGeneric<int>> AddAsync (AplicacionRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> UpdateAsync (int id,  AplicacionRequestDto request);
        Task<BaseResponseGeneric<ICollection<AplicacionResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<AplicacionResponseDto>> GetAsync(int id);
    }
}
