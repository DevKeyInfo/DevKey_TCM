using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using System.Data.SqlClient;
using WebSite.Database;
using WebSite.Utils;
using System.Security;
using System.Web.Security;
using CadastroLogin.Models;
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

            var MetodoCadastro = new CommandsSQL();
            var ValidaUsuario = MetodoCadastro.ValidarCadastro(user);


            if (ValidaUsuario == null)
            {
                User NewUser = new User
                {
                    Name = user.Name,
                    //Email = user.Email,
                    Login = user.Login,
                    Password = Hash.GerarHash(user.Password),
                };

                CommandsSQL.Insert(NewUser);
                TempData["Cadastro"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Login", "Authentication");
            }
            else { 
                    ModelState.AddModelError("Login", "Usuário não disponível");
                    return View(user);

                }

        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {

            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var MetodoLogin = new CommandsSQL();
            login = MetodoLogin.ValidarLogin(login);
            

            if (login == null)
            {
                ModelState.AddModelError("User","Usuário incorreto!");
                ModelState.AddModelError("Password","Senha incorreta!");
                return View(login);
            }

            else if (login.UserType == "ALUNO")
            {
                FormsAuthentication.SetAuthCookie(login.Id.ToString(), false);
                Session["NormalUser"] = login.Id;
                TempData["Boas-Vindas"] = "Seja bem-vindo(a), " + login.Name + "!";

            }

            else //(login.UserType == "ADM")
            {
                FormsAuthentication.SetAuthCookie(login.Id.ToString(), false);
                Session["AdmUser"] = login.Id;
                TempData["Boas-Vindas"] = "Seja bem-vindo(a), " + login.Name + "!";
            }

            return RedirectToAction("Index", "Home");

        }


        //Terminar metodo
        public ActionResult Perfil(User user)
        {
            if (Session["NormalUser"] != null)
            {

                var Id = int.Parse(Session["NormalUser"].ToString());
                User NewUser = new User();
                NewUser.ID = Id;

                var retornaPerfil = new CommandsSQL();
                var UnicoUsuario = retornaPerfil.ListarID(Id);

                return View(UnicoUsuario);
            }
            else if (Session["ADMUser"] != null)
            {

                var Id = int.Parse(Session["ADMUser"].ToString());
                User NewUser = new User();
                NewUser.ID = Id;

                var retornaPerfil = new CommandsSQL();
                var UnicoUsuario = retornaPerfil.ListarID(Id);

                return View(UnicoUsuario);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }

        }

        [HttpPost, ActionName("Perfil")]
        public ActionResult EditarPerfil(User user)
        {
            //if (ModelState.IsValid)
            //{
                var ID = int.Parse(Session["NormalUser"].ToString());
                var EditaPerfil = new CommandsSQL();
                EditaPerfil.EditarUsuario(user, ID); 
            //}
            return View();
        }

        //Traz os cursos de um determinado usuário
        public ActionResult PerfilCurso()
        {

            var ID = int.Parse(Session["NormalUser"].ToString());
            var PerfilCurso = new CommandsSQL();
            PerfilCurso.PerfilCursos(ID);

            return View(PerfilCurso);
        }
                   


        public ActionResult Logout(Login login)
        {
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }



    }
}