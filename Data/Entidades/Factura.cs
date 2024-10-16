using System;
using System.Collections.Generic;

namespace Cruceros.Data.Entidades;

public partial class Factura
{
    public int Id { get; set; }

    public int BillCod { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
