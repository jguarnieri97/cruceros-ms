using Cruceros.API.Gateway.Client;
using Cruceros.API.Habitaciones.Dto;
using Cruceros.API.Reservas.Dto;

namespace Cruceros.API.Gateway.Services
{
    public interface ICruceroService
    {
        public Task<IEnumerable<HabitacionesDto>> GetHabitaciones();
        public Task<IEnumerable<ReservasDto>> GetReservasBetweenDates(DateTime startDate, DateTime endDate);
        public Task<bool> ValidarReserva(ValidarReservaDto request);
        public Task RealizarReserva(RealizarReservaDto request);
    }

    public class CruceroService : ICruceroService
    {
        private readonly IRoomClient _roomClient;
        private readonly IReservasClient _reservasClient;

        public CruceroService(IRoomClient roomClient, IReservasClient reservasClient)
        {
            _roomClient = roomClient;
            _reservasClient = reservasClient;
        }

        public async Task<IEnumerable<HabitacionesDto>> GetHabitaciones()
        {
            return await _roomClient.GetAll();
        }

        public async Task<IEnumerable<ReservasDto>> GetReservasBetweenDates(DateTime startDate, DateTime endDate)
        {
            return await _reservasClient.GetReservasBetweenDates(startDate, endDate);
        }

        public async Task RealizarReserva(RealizarReservaDto request)
        {
            await _reservasClient.RealizarReserva(request);
        }

        public async Task<bool> ValidarReserva(ValidarReservaDto request)
        {
            return await _reservasClient.VerificarReserva(request);
        }
    }
}
