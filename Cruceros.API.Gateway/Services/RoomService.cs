using Cruceros.API.Habitaciones.Dto;

namespace Cruceros.API.Gateway.Services
{
    public interface IRoomService
    {
        public IEnumerable<HabitacionesDto> GetAll();
    }

    public class RoomService : IRoomService
    {
        private readonly IRoomService _roomService;

        public RoomService(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IEnumerable<HabitacionesDto> GetAll()
        {
            return _roomService.GetAll();
        }
    }
}
