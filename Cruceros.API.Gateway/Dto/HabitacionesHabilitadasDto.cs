namespace Cruceros.API.Gateway.Dto
{
    public class HabitacionesHabilitadasDto
    {
        public int Id { get; set; }
        public string CabinCod { get; set; }
        public double Precio { get; set; }
        public string TipoCabina { get; set; }
        public string Descripcion { get; set; }
        public bool Reservada { get; set; }
    }
}
