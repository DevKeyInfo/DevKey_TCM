﻿using System;
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
        Login login = new Login();


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

            //var MetodoCadastro = new CommandsSQL();
            //user = MetodoCadastro.ValidarCadastro(user);


            //if (user.Login != null)
            //{
            //    ModelState.AddModelError("Login", "O usuário não está disponível");
            //    return View(user);
            //}

            User NewUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = Hash.GerarHash(user.Password),
            };

            CommandsSQL.Insert(NewUser);

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
         
            var MetodoLogin = new CommandsSQL();
            login = MetodoLogin.ValidarLogin(login);
            

            if (login == null)
            {
                ModelState.AddModelError("User","Usuário incorreto!");
                ModelState.AddModelError("Password","Senha incorreta!");
                return View(login);
            }
            //Session["Login_user"].ToString();
            //Session["Password_user"].ToString();
            

            return RedirectToAction("Index", "Home");

        }



    }
}