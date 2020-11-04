using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class N_categoria
    {
        D_categorias objDato = new D_categorias();
        public List<E_categorias>ListarCategoria(string buscar)
        {
            return objDato.ListarCategorias(buscar);
        }

        public void InsertandoCategoria(E_categorias categorias)
        {
            objDato.insertarCategoria(categorias);
        }
        public void EditandoCategoria(E_categorias categoria)
        {
            objDato.EditarCategoria(categoria);

        }
        public void EliminandoCategoria(E_categorias categoria)
        {
            objDato.EliminarCategoria(categoria);
        }
        


        
    }
}
