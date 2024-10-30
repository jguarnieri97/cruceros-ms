using Cruceros.API.Reservas.Dto;
using Cruceros.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cruceros.API.Reservas.Repository
{
    public interface IReservasRepository
    {
        public IEnumerable<Reserva> GetReservasBetweenDates(DateOnly dateFrom, DateOnly dateTo);
        void RealizarReserva(RealizarReservaDto realizarReservaDto);
        bool VerificarReserva(RealizarReservaDto realizarReservaDto);
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
            return _ctx.Reservas.Include(x => x.DateCodNavigation)
                .Where(r => r.DateCodNavigation.DateStart >= dateFrom && r.DateCodNavigation.DateEnd <= dateTo)
                .ToList();
        }

        public bool VerificarReserva(RealizarReservaDto realizarReservaDto)
        {
            var estaReservado = _ctx.Reservas.Include(r => r.DateCodNavigation)
                                  .Any(r => r.CabinCod == realizarReservaDto.CabinCod &&
                                ((DateOnly.FromDateTime(realizarReservaDto.DateStart) <= r.DateCodNavigation.DateEnd && DateOnly.FromDateTime(realizarReservaDto.DateStart) >= r.DateCodNavigation.DateStart) ||
                                (DateOnly.FromDateTime(realizarReservaDto.DateEnd) <= r.DateCodNavigation.DateEnd && DateOnly.FromDateTime(realizarReservaDto.DateEnd) >= r.DateCodNavigation.DateStart)));

            return estaReservado;
        }

        public void RealizarReserva(RealizarReservaDto realizarReservaDto)
        {
            var fecha = new Fecha
            {
                DateStart = DateOnly.FromDateTime(realizarReservaDto.DateStart),
                DateEnd = DateOnly.FromDateTime(realizarReservaDto.DateEnd)
            };

            _ctx.Fechas.Add(fecha);
            _ctx.SaveChanges();

            var factura = new Factura
            {
                BillCod = DateTime.Now.GetHashCode(),
                FirstName = realizarReservaDto.FirstName,
                LastName = realizarReservaDto.LastName
            };

            _ctx.Facturas.Add(factura);
            _ctx.SaveChanges();

            var reserva = new Reserva
            {
                Cod = realizarReservaDto.Cod,
                User = realizarReservaDto.User,
                CabinCod = realizarReservaDto.CabinCod,
                BillCod = factura.Id,
                DateCod = fecha.Id,
                BillCodNavigation = factura,
                DateCodNavigation = fecha
            };

            _ctx.Reservas.Add(reserva);
            _ctx.SaveChanges();
        }
    }
}
