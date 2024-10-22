namespace Cruceros.API.Reservas.Dto
{
    public class ReservasDto
    {
        public int Id { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
        public string CabinCod { get; set; }
    }
}
