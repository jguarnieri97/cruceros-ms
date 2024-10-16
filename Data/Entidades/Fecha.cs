using System;
using System.Collections.Generic;

namespace Cruceros.Data.Entidades;

public partial class Fecha
{
    public int Id { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
