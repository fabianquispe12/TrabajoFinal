using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajoFinal.Models.Usuario
{
    public class Usuario
    {
        public int codigo_usuario {  get; set; }  
        
        public string nombre { get; set; }  
        public string ap_paterno { get; set; }  

        public string ap_materno { get; set; }  
        public string celular {  get; set; }    
        public string email { get; set; }
        public string contrasena { get; set; }
        public char estado { get; set;}
        public string codigo_rol {  get; set; }
        public string nombre_rol { get; set; }
    }
}