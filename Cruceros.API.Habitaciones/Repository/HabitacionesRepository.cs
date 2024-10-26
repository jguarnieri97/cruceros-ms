using Cruceros.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cruceros.API.Habitaciones.Repository
{

    public interface IHabitacionesRepository
    {
        public List<Cabina> GetAll();
    }
    public class HabitacionesRepository : IHabitacionesRepository
    {
        private CrucerosContext _ctx;

        public HabitacionesRepository(CrucerosContext ctx)
        {
            _ctx = ctx;
        }

        public List<Cabina> GetAll()
        {
            return _ctx.Cabinas.Include(x => x.TypeNavigation).ToList();
        }
    }
}
