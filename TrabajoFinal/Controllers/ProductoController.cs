using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        public ActionResult Create(FormCollection collection, HttpPostedFileBase imagen)
        {
            try
            {
                ProductoDAO productoDAO = new ProductoDAO();
                Producto producto = new Producto();
                
                WebImage webImage = new WebImage(imagen.InputStream);
                byte[] imagenBit = webImage.GetBytes();
                producto.producto = collection["producto"];
                producto.descripcion = collection["descripcion"];
                producto.precio = Convert.ToDecimal(collection["precio"]);
                producto.stock = Convert.ToInt32(collection["stock"]);
                producto.imagen = imagenBit;
                producto.codigo_usuario = 2;
                producto.codigo_categoria = collection["codigo_categoria"];
                

                int registrado =  productoDAO.RegistrarProducto(producto);
                if(registrado == 1)
                {
                return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Create");
                }

               

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
