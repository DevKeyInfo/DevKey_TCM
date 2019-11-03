using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using CadastroLogin.Models;
using WebSite.Database;

namespace WebSite.Controllers
{
    public class CursosController : Controller
    {
        CommandsSQL CommandsSQL = new CommandsSQL();
        DBConnection DBConnection = new DBConnection();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarCurso()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCurso(Cursos curso)
        {
            if (!ModelState.IsValid)     
            {
                return View(curso);
            }

            Cursos NewCurso = new Cursos
            {
                Nome = curso.Nome,
                Desc_cur = curso.Desc_cur,
                Id_Categoria = curso.Id_Categoria,
                Aula1 = curso.Aula1,
                Aula2 = curso.Aula2,
                Aula3 = curso.Aula3,
                Aula4 = curso.Aula4,
                Aula5 = curso.Aula5,
                Aula6 = curso.Aula6,
                Aula7 = curso.Aula7,
                Aula8 = curso.Aula8,
                Aula9 = curso.Aula9,
                Aula10 = curso.Aula10,
            };
            CommandsSQL.InserirCurso(NewCurso);

            return RedirectToAction("Index", "Home");


        }
        public ActionResult ListarCursos(Cursos curso)
        {
            var RetornarCursos = new CommandsSQL();
            var TodosCursos = RetornarCursos.ListarCursos();
            return View(TodosCursos);
        }
    }
}