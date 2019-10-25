using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using System.Data.SqlClient;
using WebSite.Database;
using WebSite.Utils;

namespace WebSite.Controllers
{
    public class AuthenticationController : Controller
    {
        CommandsSQL CommandsSQL = new CommandsSQL();
        DBConnection DBConnection = new DBConnection();
        User user = new User();
        

        // GET: Authentication
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            
            //Criar tratamento para usuarios que ja existem

            User usuario = new User
            {

                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = Hash.GerarHash(user.Password)
            };

            CommandsSQL.Insert(user);

            return RedirectToAction("Index", "Home");
            
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login loginUser)
        {
            if (!ModelState.IsValid)
            {
                return View(loginUser);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}