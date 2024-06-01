using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrabajoFinal.Models.Producto
{
    public class ProductoDAO
    {

        public int RegistrarProducto(Producto producto)
        {
            int m = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {



                    SqlCommand cmd = con.CreateCommand();
                    cmd.Transaction = tran;
                    cmd.CommandText = "RegistrarProducto";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@producto", producto.producto);
                    cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    cmd.Parameters.AddWithValue("@stock", producto.stock);
                    cmd.Parameters.AddWithValue("@image", producto.imagen);
                    cmd.Parameters.AddWithValue("@estado", '1');
                    cmd.Parameters.AddWithValue("@codigo_categoria", producto.codigo_categoria);
                    cmd.Parameters.AddWithValue("@codigo_usuario", producto.codigo_usuario);

                    m = cmd.ExecuteNonQuery();
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
            }
            return m;
        }

        public List<Producto> ListarProductosPorCategoria(string codigo)
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                }
            }
            catch
            {
                throw new Exception("Error");
            }
            return productos;
        }
    }
}