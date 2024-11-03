using Cruceros.API.Gateway.Client;
using Cruceros.API.Gateway.Dto;
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
        public List<HabitacionesHabilitadasDto> ConcatenerHabitacionesConReservas(IEnumerable<HabitacionesDto> habitacionesDtos, IEnumerable<ReservasDto> reservasDtos);
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

        public List<HabitacionesHabilitadasDto> ConcatenerHabitacionesConReservas(IEnumerable<HabitacionesDto> habitacionesDtos, IEnumerable<ReservasDto> reservasDtos)
        {
            Console.WriteLine("Servicio: Gateway - INFO - Procesando reservas y habitaciones");
            var habitacionesHabilitadas = new List<HabitacionesHabilitadasDto>();
            if (reservasDtos is not null)
            {
                habitacionesHabilitadas = habitacionesDtos.Select(h => new HabitacionesHabilitadasDto
                {
                    Id = h.Id,
                    CabinCod = h.CabinCod,
                    Precio = h.Precio,
                    TipoCabina = h.TipoCabina,
                    Descripcion = h.Descripcion,
                    Reservada = reservasDtos.Any(r => r.CabinCod == h.CabinCod)
                }).ToList();
                return habitacionesHabilitadas;
            }

            habitacionesHabilitadas = habitacionesDtos.Select(h => new HabitacionesHabilitadasDto
            {
                Id = h.Id,
                CabinCod = h.CabinCod,
                Precio = h.Precio,
                TipoCabina = h.TipoCabina,
                Descripcion = h.Descripcion,
                Reservada = false
            }).ToList();
            return habitacionesHabilitadas;


        }
    }
}
