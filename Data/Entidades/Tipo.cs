using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cruceros.Data.Entidades;

public partial class Tipo
{
    public int Id { get; set; }

    public string Identify { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    [JsonIgnore]
    public virtual ICollection<Cabina> Cabinas { get; set; } = new List<Cabina>();
}
