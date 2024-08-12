using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Entities
{
    public class AppSettings
    {
        public Jwt Jwt { get; set; }
    }

    public class Jwt
    {
        public string JWTKey{ get; set; }
        public int LifetimeInSeconds { get; set; }
    }
}
