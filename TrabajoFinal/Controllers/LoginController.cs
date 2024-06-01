using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Models.Usuario;

namespace TrabajoFinal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            Usuario user = new Usuario();
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            string email = collection["username"];
            string password = collection["password"];
            user = usuarioDAO.ValidarUsuario(email, password);

            if(user == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session["usuario"] = user;
                ViewBag.Usuario = user;
                return RedirectToAction("Index","Home");
            }

        }
    }
}