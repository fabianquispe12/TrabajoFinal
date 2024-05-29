using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Models;
using TrabajoFinal.Models.Categoria;
using TrabajoFinal.Models.Producto;

namespace TrabajoFinal.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            IEnumerable<Categoria> categorias = categoriaDAO.ListarCategorias();
            ViewBag.Categorias = categorias;
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Producto producto = new Producto();
                ProductoDAO productoDAO = new ProductoDAO();
                producto.producto = collection["producto"];
                producto.descripcion = collection["descripcion"];
                producto.precio = Convert.ToDecimal(collection["precio"]);
                producto.stock = Convert.ToInt32(collection["stock"]);
                byte[] data;
                Console.WriteLine(collection["imagen"]);
                    char state = (collection["estado"] == "true") ? '1' : '0';
                producto.estado = state;
                producto.codigo_categoria = collection["codigo_categoria"];
                producto.codigo_usuario = Convert.ToInt32(collection["codigo_usuario"]);

                int registrado =  productoDAO.RegistrarProducto(producto);

               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
