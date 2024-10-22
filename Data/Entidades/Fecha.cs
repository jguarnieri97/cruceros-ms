using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cruceros.Data.Entidades;

public partial class Fecha
{
    public int Id { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
