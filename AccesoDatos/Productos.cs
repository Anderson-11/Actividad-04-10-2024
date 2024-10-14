using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Productos
    {
        public string IdProducto { get; set; } // ID autoincremental
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Proveedor { get; set; }
    }
}
