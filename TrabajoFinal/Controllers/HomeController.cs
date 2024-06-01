using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Models.Categoria;

namespace TrabajoFinal.Controllers
{
    public class HomeController : Controller
    {
        CategoriaDAO categoriaDAO = new CategoriaDAO();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Categorias()
        {
            ViewBag.Message = "Categorias";

            IEnumerable<Categoria> categorias = categoriaDAO.ListarDetalleCategorias();
            ViewBag.Categorias = categorias;
            return View();
        }

        //public ActionResult Categoria(string codigo_categoria) {
        
        
        //}
    }
}