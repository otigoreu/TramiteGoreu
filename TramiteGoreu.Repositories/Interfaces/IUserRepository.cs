﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace TramiteGoreu.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario?> GetAsync(string id);
    }
}
