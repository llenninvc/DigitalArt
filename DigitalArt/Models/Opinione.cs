using System;
using System.Collections.Generic;

namespace DigitalArt.Models;

public partial class Opinione
{
    public int IdOpinion { get; set; }

    public string? NombreOpinion { get; set; }

    public string? DescripcionOpinion { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
