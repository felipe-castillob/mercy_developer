using System;
using System.Collections.Generic;

namespace mercy_developer.Models;

public partial class Recepcionequipo
{
    public int Id { get; set; }

    public int ServicioId { get; set; }

    public int ClienteId { get; set; }

    public DateTime Fecha { get; set; }

    public int TipoPc { get; set; }

    public string Accesorio { get; set; } = null!;

    public string MarcaPc { get; set; } = null!;

    public string ModeloPc { get; set; } = null!;

    public string Nserie { get; set; } = null!;

    public int CapacidadRam { get; set; }

    public int TipoAlmacenamiento { get; set; }

    public string CapacidadAlmacenamiento { get; set; } = null!;

    public int TipoGpu { get; set; }

    public string Grafico { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;
}
