using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad
{
    public class E_categorias
    {
        private int idCategorias;
        private string codigoCategorias;
        private string nombre;
        private string descripcion;

        public int IdCategorias { get => idCategorias; set => idCategorias = value; }
        public string CodigoCategorias { get => codigoCategorias; set => codigoCategorias = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
