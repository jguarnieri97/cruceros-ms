using System;
using System.Collections.Generic;

namespace Cruceros.Data.Entidades;

public partial class Reserva
{
    public int Id { get; set; }

    public string Cod { get; set; } = null!;

    public string User { get; set; } = null!;

    public string CabinCod { get; set; } = null!;

    public int BillCod { get; set; }

    public int DateCod { get; set; }

    public virtual Factura BillCodNavigation { get; set; } = null!;

    public virtual Cabina CabinCodNavigation { get; set; } = null!;

    public virtual Fecha DateCodNavigation { get; set; } = null!;

}
