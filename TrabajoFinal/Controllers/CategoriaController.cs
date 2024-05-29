using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Models.Categoria;

namespace TrabajoFinal.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            CategoriaDAO categorias = new CategoriaDAO();
            IEnumerable<Categoria> cats = categorias.ListarCategorias();
            return View(cats);
        }
    }
}