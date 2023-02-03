using System;
using System.Collections.Generic;

namespace DigitalArt.Models;

public partial class Arte
{
    public int IdArte { get; set; }

    public string? NombreArte { get; set; }

    public string? DescripcionArte { get; set; }

    public string? LinkArte { get; set; }

    public string? Img { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
