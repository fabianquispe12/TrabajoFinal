using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Models.Usuario;

namespace TrabajoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            IEnumerable<Usuario> usuarios = usuarioDAO.listarUsuario();
            return View(usuarios);
        }
    }
}