using System;
using System.Collections.Generic;

namespace Cruceros.Data.Entidades;

public partial class Cabina
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string CabinCod { get; set; } = null!;

    public int Type { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual Tipo TypeNavigation { get; set; } = null!;
}
