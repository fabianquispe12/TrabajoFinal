using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
namespace TrabajoFinal.Models.Categoria
{
    public class CategoriaDAO
    {

        public static void main(string[] args)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
                Console.WriteLine("conexion exitosa");
            }catch (Exception ex)
            {
                Console.WriteLine("Error: ",ex.Message);
            }

        
        }
          
        public List<Categoria> ListarCategorias()
        {
                List<Categoria> categorias = new List<Categoria>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {
                  
                    con.Open();
                    //Creamos el comando de la conexion
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "ListarCategoria";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     //ejecutamos y lo recibimos en el dr
                    SqlDataReader dr =  cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Categoria cat = new Categoria();
                            cat.codigo_categoria = dr["codigo_categoria"].ToString();
                            cat.categoria = dr["categoria"].ToString();
                            Console.WriteLine(cat);
                            categorias.Add(cat);
                        }
                    }
                }
               
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(categorias);
            return categorias;
        }
    }
}