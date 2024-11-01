using Cruceros.API.Reservas.Dto;
using Cruceros.API.Reservas.Repository;
using Cruceros.Data.Entidades;

namespace Cruceros.API.Reservas.Services
{
    public interface IReservasService
    {
        public IEnumerable<ReservasDto> GetReservasBetweenDates(DateOnly dateFrom, DateOnly dateTo);
        void RealizarReserva(RealizarReservaDto realizarReservaDto);
        bool VerificarReserva(ValidarReservaDto realizarReservaDto);
    }
    public class ReservasService : IReservasService
    {
        private IReservasRepository _reservasRepository;

        public ReservasService(IReservasRepository reservasRepository)
        {
            _reservasRepository = reservasRepository;
        }
        public IEnumerable<ReservasDto> GetReservasBetweenDates(DateOnly dateFrom, DateOnly dateTo)
        {
            var reservas = _reservasRepository.GetReservasBetweenDates(dateFrom, dateTo);

            var reservasDto = reservas.Select(r => new ReservasDto
            {
                Id = r.Id,
                DateFrom = r.DateCodNavigation.DateStart,
                DateTo = r.DateCodNavigation.DateEnd,
                CabinCod = r.CabinCod
            });


            return reservasDto;
        }

        public bool VerificarReserva(ValidarReservaDto realizarReservaDto)
        {
            return _reservasRepository.VerificarReserva(realizarReservaDto);
        }

        public void RealizarReserva(RealizarReservaDto realizarReservaDto)
        {
            try
            {
                _reservasRepository.RealizarReserva(realizarReservaDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
