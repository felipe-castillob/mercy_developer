using System;
using System.Collections.Generic;

namespace mercy_developer.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string RutCliente { get; set; } = null!;

    public string NombreCliente { get; set; } = null!;

    public string ApellidoCliente { get; set; } = null!;

    public string CorreoCliente { get; set; } = null!;

    public string DireccionCliente { get; set; } = null!;

    public string TelefonoCliente { get; set; } = null!;

    public DateTime FechaInscripcionCliente { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<Recepcionequipo> Recepcionequipos { get; set; } = new List<Recepcionequipo>();
}
