using Cruceros.API.Gateway.Dto;

namespace Cruceros.MVC.Web.Models
{
    public class HabitacionesViewModel
    {
        public HabitacionesViewModel(IEnumerable<HabitacionesHabilitadasDto> habitacionesHabilitadasDto)
        {
            A = habitacionesHabilitadasDto.Where(x => x.TipoCabina == "A").ToList();
            B = habitacionesHabilitadasDto.Where(x => x.TipoCabina == "B").ToList();
            C = habitacionesHabilitadasDto.Where(x => x.TipoCabina == "C").ToList();
        }
        public IEnumerable<HabitacionesHabilitadasDto> A { get; set; }
        public IEnumerable<HabitacionesHabilitadasDto> B { get; set; }
        public IEnumerable<HabitacionesHabilitadasDto> C { get; set; }
    }
}
