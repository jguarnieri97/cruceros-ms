namespace Cruceros.API.Reservas.Dto;

public class ValidarReservaDto
{
    public string CabinCod { get; set; } = null!;
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }

    public ValidarReservaDto(string cabinCod, DateTime dateStart, DateTime dateEnd)
    {
        CabinCod = cabinCod;
        DateStart = dateStart;
        DateEnd = dateEnd;
    }
}
