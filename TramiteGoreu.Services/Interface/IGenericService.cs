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
    public interface IGenericService<T> where T : class
    {
        //Task<BaseResponseGeneric<int>> AddAsync(EntidadRequestDto request);
        //Task<BaseResponseGeneric<int>> AddAsyncSingle(EntidadRequestDtoSingle request);
        //Task<BaseResponse> DeleteAsync(int id); 
        //Task<BaseResponse> UpdateAsync(int id, EntidadRequestDto request);
        //Task<BaseResponseGeneric<ICollection<EntidadResponseDto>>> GetAsync();
        //Task<BaseResponseGeneric<EntidadResponseDto>> GetAsync(int id);
        //Task<BaseResponseGeneric<ICollection<EntidadInfo>>> GetAsync(string? descripcion);
        //Task<BaseResponseGeneric<ICollection<EntidadInfoSede>>> GetAsyncWithSede(string? descripcion);
        //Task<BaseResponse> FinalizedAsync(int id);
        //Task<BaseResponse> InitializedAsync(int id);
    }
}
