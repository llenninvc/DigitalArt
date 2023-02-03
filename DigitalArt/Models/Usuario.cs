using System;
using System.Collections.Generic;

namespace DigitalArt.Models;

public partial class Usuario
{
    public int IdUsuarios { get; set; }

    public string? NombreUsuarios { get; set; }

    public string? DireccionUsuarios { get; set; }

    public string? TelefonoUsuarios { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
