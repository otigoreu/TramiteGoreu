using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Dto.Response
{
    public class BaseResponseGeneric<T> :BaseResponse
    {
        public T? Data { get; set; }
    }
}
