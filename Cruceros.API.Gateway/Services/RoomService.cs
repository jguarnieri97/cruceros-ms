using Cruceros.API.Gateway.Client;
using Cruceros.API.Habitaciones.Dto;
using Cruceros.API.Reservas.Dto;

namespace Cruceros.API.Gateway.Services
{
    public interface IRoomService
    {
        public IEnumerable<HabitacionesDto> GetHabitaciones();
        public IEnumerable<ReservasDto> GetReservasBetweenDates(DateTime startDate, DateTime endDate);
    }

    public class RoomService : IRoomService
    {
        private readonly RoomClient _roomClient;

        public RoomService(RoomClient roomClient)
        {
            _roomClient = roomClient;
        }

        public IEnumerable<HabitacionesDto> GetHabitaciones()
        {
            return (IEnumerable<HabitacionesDto>)_roomClient.GetAll();
        }

        public IEnumerable<ReservasDto> GetReservasBetweenDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
