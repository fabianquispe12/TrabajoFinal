using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace TrabajoFinal.Models.Rol
{
    public class RolDAO
    { 
        
        public RolDAO() { }

        public List<Rol> ListarRoles()
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString)) 
                { 
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "ListarRol";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            Rol rol = new Rol()
                            {
                                codigo_rol = dr.GetString(0),
                                rol = dr.GetString(1),
                            };
                            roles.Add(rol);
                        }
                    }
                }
            }catch (Exception ex)
            {
                throw new Exception("error en la recuperación de los roles");
            }
            return roles;
        }

    }
}