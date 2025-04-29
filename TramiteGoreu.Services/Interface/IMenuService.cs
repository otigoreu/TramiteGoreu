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
    public interface IMenuService
    {

        Task<BaseResponseGeneric<int>> AddAsync(MenuRequestDto request);
        Task<BaseResponseGeneric<int>> AddAsyncSingle(MenuRequestDtoSingle request);
        Task<BaseResponseGeneric<ICollection<MenuResponseDto>>> GetByAplicationAsync(int idAplication, string email);
        Task<BaseResponseGeneric<ICollection<MenuInfo>>> GetAsync(string? displayName);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> UpdateAsync(int id, MenuRequestDto request);
        Task<BaseResponse> UpdateAsyncSingle(int id, MenuRequestDtoSingle request);
        Task<BaseResponse> FinalizedAsync(int id);
        Task<BaseResponse> InitializedAsync(int id);
    }
}
