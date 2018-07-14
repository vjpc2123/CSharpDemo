using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public  class NMarca
    {
        public static string IngresarMarca(string nombre, string descripcion)
        {
            DMarca OBJ = new DMarca();
            OBJ.Nombre = nombre;
            OBJ.Descripcion = descripcion;
            return OBJ.InsertarMarca(OBJ);
        }

    }
}
