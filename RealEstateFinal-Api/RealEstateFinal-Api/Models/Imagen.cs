using System;
using System.Collections.Generic;

namespace RealEstateFinal_Api.Models
{
    public partial class Imagen
    {
        public int IdImagen { get; set; }
        public string? UbicacionImg { get; set; }
        public int? IdInmueble { get; set; }

        public virtual Inmueble? IdInmuebleNavigation { get; set; }
    }
}
