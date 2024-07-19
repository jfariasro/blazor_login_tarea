using JOSE_FARIAS.Client.Services.Contracts;
using JOSE_FARIAS.Shared;
using System.Net.Http.Json;

namespace JOSE_FARIAS.Client.Services.Entities
{
    public class TareaService : ITareaService
    {

        private readonly HttpClient _httpClient;

        public TareaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Completar(int id, TareaDTO tareaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Tarea/Completar/{id}", tareaDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<bool> Editar(int id, TareaDTO tareaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Tarea/Editar/{id}", tareaDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<bool> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Tarea/Eliminar/{id}");

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<List<TareaDTO>> ListarCompletas()
        {
            var lista = new List<TareaDTO>();

            lista = await _httpClient.GetFromJsonAsync<List<TareaDTO>>("api/Tarea/ListarCompletada");

            return lista!;
        }

        public async Task<List<TareaDTO>> ListarIncompleta()
        {
            var lista = new List<TareaDTO>();

            lista = await _httpClient.GetFromJsonAsync<List<TareaDTO>>("api/Tarea/ListarIncompleta");

            return lista!;
        }

        public async Task<bool> Registrar(TareaDTO tareaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Tarea/Registrar", tareaDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }
    }
}
