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


        public ActionResult Detalhes(AlunoCurso alunoCurso, int Id)
        {
            var metodoCurso = new CommandsSQL();
            metodoCurso.ListadId(Id);

            AlunoCurso alunoCurso2 = new AlunoCurso
            {
                id_user = Convert.ToInt32(Session["NormalUser"].ToString()),
                id_curso = Id,
            };
                //Verifica se o usuário já é inscrito no curso
                var retorno = metodoCurso.ValidaCadastroCurso(alunoCurso2);
                //Retorna tela do curso
                var curso = metodoCurso.DetalheCurso(Id);

            if (retorno == null)
            {
                AlunoCurso IdentificacaoLogin = new AlunoCurso
                {
                    id_user = int.Parse(Session["NormalUser"].ToString()),
                    id_curso = Id,
                };

                metodoCurso.CursoAluno(IdentificacaoLogin);
                //COMO RETORNAR O CURSO?
                return View(curso);
            }
            else
            {

                return View(curso);
            }

        }

        //Terminar o metodo
        //public ActionResult Categorias(Cursos cursos)
       // {
            //------------------------------Usar uma das query's------------------------------ 
            //      SELECT c.id_curso, c.Nome, c.desc_cur, cc.desc_cat
            //      FROM curso c, categoria cc
            //      WHERE c.Id_Categoria = cc.Id_Categoria

            //      SELECT* FROM
            //      Curso, Categoria
            //      Where Curso.Id_Categoria = Categoria.Id_Categoria

       // }
    }
}