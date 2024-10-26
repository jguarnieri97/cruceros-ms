using Cruceros.API.Reservas.Dto;
using Cruceros.API.Reservas.Repository;
using Cruceros.Data.Entidades;

namespace Cruceros.API.Reservas.Services
{
    public interface IReservasService
    {
        public IEnumerable<ReservasDto> GetReservasBetweenDates(DateOnly dateFrom, DateOnly dateTo);
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
    }
}
