﻿using Goreu.Tramite.Entities.info;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IAplicacionRepository : IRepositoryBase<Aplicacion>
    {
        Task<ICollection<AplicacionInfo>> GetAsync(string? descripcion);
        Task<ICollection<AplicacionInfoSede>> GetAsyncWithSede(string? descripcion);
        Task FinalizedAsync(string id);
        Task InitializedAsync(string id);
    }
}
