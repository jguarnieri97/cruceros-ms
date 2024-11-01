﻿namespace Cruceros.API.Reservas.Dto
{
    public class RealizarReservaDto
    {
        public RealizarReservaDto(string cod, string user, string cabinCod, DateTime dateStart, DateTime dateEnd, string firstName, string lastName)
        {
            Cod = cod;
            User = user;
            CabinCod = cabinCod;
            DateStart = dateStart;
            DateEnd = dateEnd;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Cod { get; set; } = null!;
        public string User { get; set; } = null!;
        public string CabinCod { get; set; } = null!;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}