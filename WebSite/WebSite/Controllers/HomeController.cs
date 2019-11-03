using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Database;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //Terminar de configurar Authorize
        //[Authorize(Roles = "Adminstrador")]
        public ActionResult ListarUsuarios(User user)
        {
            //if(Session["Login_user"] == null && Session["Password_user"] == null)
            //{
            //    RedirectToAction("Login", "Authentication");
            //}
            var RetornarAlunos = new CommandsSQL();
            var TodosUsuarios = RetornarAlunos.Listar();
            return View(TodosUsuarios);
        }


    }
}