using Cruceros.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cruceros.API.Reservas.Repository
{
    public interface IReservasRepository
    {
        public IEnumerable<Reserva> GetReservasBetweenDates(DateOnly dateFrom, DateOnly dateTo);
    }
    public class ReservasRepository : IReservasRepository
    {
        private CrucerosContext _ctx;

        public ReservasRepository(CrucerosContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Reserva> GetReservasBetweenDates(DateOnly dateFrom, DateOnly dateTo)
        {
            //return _ctx.Reservas.Include(x => x.DateCodNavigation).ToList();
            return _ctx.Reservas.Include(x => x.DateCodNavigation)
                .Where(r => r.DateCodNavigation.DateStart >= dateFrom && r.DateCodNavigation.DateEnd <= dateTo)
                .ToList();
        }
    }
}
