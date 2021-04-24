using System;
using System.Collections.Generic;
using System.Text;

namespace final_project
{
    public class Product
    {
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Descripcion { get; set; }
        public string Cantidad { get; set; }
        public string Imagen { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
