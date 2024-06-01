using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;
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

        public ActionResult Create()
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            IEnumerable<Categoria> cats = categoriaDAO.ListarCategorias();
            ViewBag.Categorias = cats;
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase imagen) 
        {
            Categoria categoria = new Categoria();
            CategoriaDAO categoriaDAO = new CategoriaDAO();

            categoria.codigo_categoria = collection["codigo_categoria"];
            categoria.descripcion = collection["descripcion"];

            WebImage webImage = new WebImage(imagen.InputStream);

            categoria.imagen = webImage.GetBytes();

            int m = categoriaDAO.AgregarDetalleCategoria(categoria);

            if(m == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }

        }
    }
}