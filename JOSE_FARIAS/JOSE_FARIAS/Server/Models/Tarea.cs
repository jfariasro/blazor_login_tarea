using System;
using System.Collections.Generic;

namespace JOSE_FARIAS.Server.Models;

public partial class Tarea
{
    public int Idtarea { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Completada { get; set; }
}
