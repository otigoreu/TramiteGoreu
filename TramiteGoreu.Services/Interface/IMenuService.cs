using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;

namespace TramiteGoreu.Services.Interface
{
    public interface IMenuService
    {

        Task<BaseResponseGeneric<int>> AddAsync(MenuRequestDto request);
        Task<BaseResponseGeneric<ICollection<MenuResponseDto>>> GetByAplicationAsync(int idAplication, string email);
    }
}
