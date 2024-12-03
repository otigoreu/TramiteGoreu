using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
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
        Task<BaseResponseGeneric<ICollection<MenuResponseDto>>> GetByAplicationAsync(int idAplication, string email);
    }
}
