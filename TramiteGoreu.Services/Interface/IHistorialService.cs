namespace Goreu.Tramite.Services.Interface
{
    public interface IHistorialService
    {
        Task<BaseResponseGeneric<int>> AddAsync(HistorialRequestDto request);
    }
}
