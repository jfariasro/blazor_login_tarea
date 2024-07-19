using JOSE_FARIAS.Shared;

namespace JOSE_FARIAS.Client.Services.Contracts
{
    public interface ITareaService
    {
        Task<List<TareaDTO>> ListarIncompleta();

        Task<List<TareaDTO>> ListarCompletas();

        Task<bool> Registrar(TareaDTO tareaDTO);

        Task<bool> Editar(int id, TareaDTO tareaDTO);

        Task<bool> Eliminar(int id);

        Task<bool> Completar(int id, TareaDTO tareaDTO);
    }
}
