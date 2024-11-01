using Cruceros.API.Habitaciones.Dto;
using Cruceros.API.Habitaciones.Repository;

namespace Cruceros.API.Habitaciones.Services
{
    public interface IHabitacionesService
    {
        public IEnumerable<HabitacionesDto> GetAll();
    }

    public class HabitacionesService : IHabitacionesService
    {
        private IHabitacionesRepository _habitacionesRepository;

        public HabitacionesService(IHabitacionesRepository habitacionesRepository)
        {
            _habitacionesRepository = habitacionesRepository;
        }

        public IEnumerable<HabitacionesDto> GetAll()
        {
            var habitaciones = _habitacionesRepository.GetAll();

            var habitacionesDTO = habitaciones.Select(h => new HabitacionesDto
            {
                Id = h.Id,
                CabinCod = h.CabinCod,
                Precio = h.TypeNavigation.Price,
                TipoCabina = h.TypeNavigation.Identify,
                Descripcion = h.TypeNavigation.Description
            });

            return habitacionesDTO;

        }
    }
}
