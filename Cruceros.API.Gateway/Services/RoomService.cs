using Cruceros.API.Habitaciones.Dto;
using Cruceros.API.Reservas.Dto;
using System.Text.Json;

namespace Cruceros.API.Gateway.Services
{
    public interface IRoomService
    {
        public IEnumerable<HabitacionesDto> GetAll();
        public IEnumerable<HabitacionesDto> GetHabitaciones();
        public IEnumerable<ReservasDto> GetReservasBetweenDates(DateTime startDate, DateTime endDate);
    }

    public class RoomService : IRoomService
    {
        private readonly IRoomService _roomService;
        private readonly HttpClient _httpClient;

        public RoomService(IRoomService roomService, HttpClient httpClient)
        {
            _roomService = roomService;
            _httpClient = httpClient;
        }

        public IEnumerable<HabitacionesDto> GetAll()
        {
            return _roomService.GetAll();
        }

        public IEnumerable<HabitacionesDto> GetHabitaciones()
        {
            var response = _httpClient.GetAsync("/api/Habitaciones/ObtenerTodas").Result;

            if (response.IsSuccessStatusCode)
            {
                var contenidoJson = response.Content.ReadAsStringAsync().Result;
                var habitaciones = JsonSerializer.Deserialize<List<HabitacionesDto>>(contenidoJson);

                return habitaciones;
            }
            return null;
        }

        public IEnumerable<ReservasDto> GetReservasBetweenDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
