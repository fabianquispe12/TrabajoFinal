using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Models.Rol;

namespace TrabajoFinal.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Index()
        {
            RolDAO rolDAO = new RolDAO();
            IEnumerable<Rol> roles = rolDAO.ListarRoles();
            return View(roles);
        }
    }
}