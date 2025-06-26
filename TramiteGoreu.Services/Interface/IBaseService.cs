using Azure.Core;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Services.Interface
{
    public interface IBaseService<TRequest, TResponse>
    {
        Task<BaseResponseGeneric<int>> AddAsync(TRequest request);
        Task<BaseResponse> UpdateAsync(int id, TRequest request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> FinalizeAsync(int id);
        Task<BaseResponse> InitializeAsync(int id);
        Task<BaseResponseGeneric<TResponse>> GetAsync(int id);
    }
}
