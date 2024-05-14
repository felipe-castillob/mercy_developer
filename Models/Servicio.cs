using System;
using System.Collections.Generic;

namespace mercy_developer.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public int PrecioServicio { get; set; }

    public string Sku { get; set; } = null!;

    public int UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
