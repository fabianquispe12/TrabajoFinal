using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrabajoFinal.Models.Usuario
{
    public class UsuarioDAO
    {

        public List<Usuario> listarUsuario() { 
         
            List<Usuario> usuarios = new List<Usuario>();

            try {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "ListarUsuario";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        throw new Exception("error al listar");
                    }

                    while (dr.Read())
                    {
                        Usuario user = new Usuario();
                        Console.WriteLine(dr);
                            user.codigo_usuario = (int)Convert.ToInt64(dr["codigo_usuario"]);
                            user.nombre = dr["nombre"].ToString();
                            user.ap_paterno = dr["ap_paterno"].ToString();
                            user.ap_materno = dr["ap_materno"].ToString();
                            user.celular = dr["celular"].ToString();
                            user.email = dr["email"].ToString();
                            user.contrasena = dr["contrasena"].ToString();
                            user.estado = Convert.ToChar(dr["estado"].ToString());
                            user.codigo_rol = dr["codigo_rol"].ToString();
                            user.nombre_rol = dr["rol"].ToString();
                        usuarios.Add(user);
                    }
                    
                } 

            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return usuarios;
        }
    }
}