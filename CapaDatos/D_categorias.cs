using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data;
namespace CapaDatos
{
    public class D_categorias

    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_categorias> ListarCategorias(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            leerFilas = cmd.ExecuteReader();
            List<E_categorias> Listar = new List<E_categorias>();
            while (leerFilas.Read())
            {
                Listar.Add(new E_categorias
                {
                    IdCategorias = leerFilas.GetInt32(0),
                    CodigoCategorias = leerFilas.GetString(1),
                    Nombre = leerFilas.GetString(2),
                    Descripcion = leerFilas.GetString(3)

                });


            }
            conexion.Close();
            leerFilas.Close();
            return Listar;

        }



        public void insertarCategoria(E_categorias categorias)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", categorias.Nombre);
            cmd.Parameters.AddWithValue("@DESCRIPCION", categorias.Descripcion);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EditarCategoria(E_categorias categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIAS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
    
            cmd.Parameters.AddWithValue("@IDCATEGORIA", categoria.IdCategorias);
            cmd.Parameters.AddWithValue("@NOMBRE", categoria.Nombre);
            cmd.Parameters.AddWithValue("@DESCRIPCION", categoria.Descripcion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

       public void EliminarCategoria(E_categorias Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.IdCategorias);
            
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
