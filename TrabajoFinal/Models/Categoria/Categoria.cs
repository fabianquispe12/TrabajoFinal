using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajoFinal.Models.Categoria
{
    public class Categoria
    {
        public string codigo_categoria { get; set; }
        public string categoria { get; set; }

        public string descripcion { get; set;}

        public byte[] imagen { get; set; }
    }
}