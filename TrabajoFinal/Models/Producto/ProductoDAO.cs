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
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "RegistrarProducto";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@producto", producto.producto);
                    cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    cmd.Parameters.AddWithValue("@stock", producto.stock);
                    cmd.Parameters.AddWithValue("@image", producto.imagen);
                    cmd.Parameters.AddWithValue("@estado", producto.estado);
                    cmd.Parameters.AddWithValue("@codigo_categoria", producto.codigo_categoria);
                    cmd.Parameters.AddWithValue("@codigo_usuario", producto.codigo_usuario);

                    m = cmd.ExecuteNonQuery();
                }
            }catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());
            }
            return m;
        }
    }
}