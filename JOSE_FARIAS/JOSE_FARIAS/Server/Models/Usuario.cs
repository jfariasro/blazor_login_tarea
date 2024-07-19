using System;
using System.Collections.Generic;

namespace JOSE_FARIAS.Server.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }
}
