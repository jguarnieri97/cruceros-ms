using Cruceros.API.Gateway.Exceptions;
using Cruceros.API.Habitaciones.Dto;
using System.Net.Http.Headers;

namespace Cruceros.API.Gateway.Client
{
    public interface IRoomClient
    {
        public Task<IEnumerable<HabitacionesDto>> GetAll();
    }

    public class RoomClient : IRoomClient
    {
        private HttpClient _httpClient;
        private const string BASE_URI = "https://localhost:44372/api/";

        public RoomClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<HabitacionesDto>> GetAll()
        {
            try
            {
                IEnumerable<HabitacionesDto> habitaciones = (IEnumerable<HabitacionesDto>)await _httpClient.GetAsync(BASE_URI + "Habitaciones/ObtenerTodas");
                
                return habitaciones;
            }
            catch (Exception e)
            {
                throw new RoomClientException(e.Message);
            }
        }
    }
}