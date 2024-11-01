using Cruceros.API.Gateway.Client;
using Cruceros.API.Habitaciones.Dto;
using Cruceros.API.Reservas.Dto;

namespace Cruceros.API.Gateway.Services
{
    public interface ICruceroService
    {
        public Task<IEnumerable<HabitacionesDto>> GetHabitaciones();
        public IEnumerable<ReservasDto> GetReservasBetweenDates(DateTime startDate, DateTime endDate);
    }

    public class CruceroService : ICruceroService
    {
        private readonly IRoomClient _roomClient;

        public CruceroService(IRoomClient roomClient)
        {
            _roomClient = roomClient;
        }

        public async Task<IEnumerable<HabitacionesDto>> GetHabitaciones()
        {
            return await _roomClient.GetAll();
        }

        public IEnumerable<ReservasDto> GetReservasBetweenDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
