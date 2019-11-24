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


        public ActionResult ListarUsuarios()
        {

            if (Session["ADMUser"] != null)
            {
                var RetornarAlunos = new CommandsSQL();
                var TodosUsuarios = RetornarAlunos.Listar();
                return View(TodosUsuarios);
            }
            else 
            {
                return RedirectToAction("Login", "Authentication");
            }

            
        }


    }
}