using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajoFinal.Models.Producto
{
    
    public class Producto
    {
        public int codigo_producto {  get; set; }
        public string producto { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock {  get; set; }
        public string imagen { get; set; }

        public HttpPostedFileBase Image { get; set; }
        public char estado {  get; set; }
        public string codigo_categoria { get; set; }

        public string categoria { get; set; }
        public int codigo_usuario {  get; set; }

        public string usuario { get; set; }
    }
}