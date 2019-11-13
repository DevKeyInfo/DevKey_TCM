using WebSite.Models;
using WebSite.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CadastroLogin.Models;

namespace WebSite.Database
{
    public class CommandsSQL
    {
        private DBConnection db;

        //INSERE ALUNO_CURSO
        public void CursoAluno(AlunoCurso alunoCurso)
        {
            var StrQuery = string.Format("INSERT INTO Aluno_Curso (Id_User, Id_Curso) VALUES ({0}, {1})", alunoCurso.id_user, alunoCurso.id_curso);

            using (db = new DBConnection())
            {
                db.ExecuteCommand(StrQuery);
            }
        }

        public void InserirCurso(Cursos curso)
        {
            var StrQuery = "";
            StrQuery += "INSERT INTO Curso(Nome, desc_cur, Id_categoria, aula1, aula2, aula3, aula4, aula5, aula6, aula7, aula8, aula9, aula10)";
            StrQuery += string.Format("VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", curso.Nome, curso.Desc_cur, curso.Id_Categoria,
            curso.Aula1, curso.Aula2, curso.Aula3, curso.Aula4, curso.Aula5, curso.Aula6, curso.Aula7, curso.Aula8, curso.Aula9, curso.Aula10);

            using (db = new DBConnection())
            {
                db.ExecuteCommand(StrQuery);
            }
        }
        //Metodo para inserir usuários
        public void Insert(User user)
        {
            var StrQuery = "";
            StrQuery += "INSERT INTO tb_User(Name_User, Login_User, Password_User)";
            StrQuery += string.Format("VALUES('{0}', '{1}', '{2}')", user.Name, user.Login, user.Password);

            using (db = new DBConnection())
            {
                db.ExecuteCommand(StrQuery);
            }
        }


        //Listar usuarios ja registrados no sistema
        public List<User> Listar()
        {
            var db = new DBConnection();
            var strQuery = "SELECT * FROM tb_User;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeUsuario(retorno);
        }

        public List<User> ListaDeUsuario(SqlDataReader retorno)
        {
            var usuarios = new List<User>();
            
            while (retorno.Read())
            {
                var TempUsuario = new User()
                {
                    ID = int.Parse(retorno["Id_User"].ToString()),
                    Name = retorno["Name_User"].ToString(),
                    Login = retorno["Login_user"].ToString(),
                    Password = retorno["Password_user"].ToString(),
                    UserType = retorno["User_Type"].ToString()
                    
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }

        public Cursos ListadId(int Id)
        {
            using (db = new DBConnection())
            {
                var strQuery = string.Format("SELECT * FROM Curso WHERE Id_Curso = {0};", Id);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeCursos(retorno).FirstOrDefault();
            }
        }


        //Retorna lista de cursos cadastrados
        public List<Cursos> ListarCursos()
        {
            var db = new DBConnection();
            var strQuery = "SELECT * FROM Curso;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeCursos(retorno);
        }

        //Retorna lista de cursos cadastrados
        public List<Cursos> ListaDeCursos(SqlDataReader retorno)
        {
            var cursos = new List<Cursos>();

            while (retorno.Read())
            {
                var TempCurso = new Cursos()
                {
                    Nome = retorno["Nome"].ToString(),
                    Desc_cur = retorno["Desc_cur"].ToString(),
                    Id_Categoria = int.Parse(retorno["Id_Categoria"].ToString()),
                    Id_Curso = int.Parse(retorno["Id_Curso"].ToString()),
                    Aula1 = retorno["Aula1"].ToString(),
                    Aula2 = retorno["Aula2"].ToString(),
                    Aula3 = retorno["Aula3"].ToString(),
                    Aula4 = retorno["Aula4"].ToString(),
                    Aula5 = retorno["Aula5"].ToString(),
                    Aula6 = retorno["Aula6"].ToString(),
                    Aula7 = retorno["Aula7"].ToString(),
                    Aula8 = retorno["Aula8"].ToString(),
                    Aula9 = retorno["Aula9"].ToString(),
                    Aula10 = retorno["Aula10"].ToString(),
                };
                cursos.Add(TempCurso);
            }
            retorno.Close();
            return cursos;
        }

        //Valida Aluno_Curso
        public AlunoCurso ValidaCadastroCurso(AlunoCurso alunoCurso)
        {
            using (db = new DBConnection())
            {
                var strQuery = string.Format("SELECT id_user, id_curso WHERE id_user = '{0}' AND id_curso = '{1}';",alunoCurso.id_user, alunoCurso.id_curso);
                var retorno = db.RetornaComando(strQuery);

                return RetornaCadastroCurso(retorno).FirstOrDefault();
            }

        }
        public List<AlunoCurso> RetornaCadastroCurso(SqlDataReader retorno)
        {
            var usuarios = new List<AlunoCurso>();

            while (retorno.Read())
            {
                var TempUsuario = new AlunoCurso()
                {
                    id_curso = int.Parse(retorno["id_user"].ToString()),
                    id_user = int.Parse(retorno["id_curso"].ToString()),                    
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();


            return usuarios;
        }


        //Validação de login no banco de dados
        public Login ValidarLogin(Login login)
        {
            using (db = new DBConnection())
            {
                var strQuery = string.Format("SELECT id_user, name_user, login_user, password_user, RTRIM(User_Type) [user_type] FROM tb_User WHERE login_user = '{0}' AND Password_user = '{1}';",
                login.User, Hash.GerarHash(login.Password));
                var retorno = db.RetornaComando(strQuery);

                return VerificarLogin(retorno).FirstOrDefault();
            }

        }
        public List<Login> VerificarLogin(SqlDataReader retorno)
        {
            var usuarios = new List<Login>();

            while (retorno.Read())
            {
                var TempUsuario = new Login()
                {
                    Id = int.Parse(retorno["id_user"].ToString()),
                    Name = retorno["name_user"].ToString(),
                    User = retorno["Login_user"].ToString(),
                    Password = retorno["Password_user"].ToString(),
                    UserType = retorno["User_Type"].ToString(),
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }



        //Verifica se o usuario ja existe no banco de dados
        public User ValidarCadastro(User user)
        {
            using (db = new DBConnection())
            {
                var strQuery = string.Format("SELECT * FROM tb_User WHERE Login_user = '{0}';", user.Login);
                var retorno = db.RetornaComando(strQuery);
                return VerificarCadastro(retorno).FirstOrDefault();
            }

        }

        public List<User> VerificarCadastro(SqlDataReader retorno)
        {
            var usuarios = new List<User>();

            while (retorno.Read())
            {
                var TempUsuario = new User()
                {
                    Login = retorno["Login_user"].ToString(),
                    Name = retorno["Name_User"].ToString(),
                    Password = retorno["Password_user"].ToString(),
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }

        //SEPARAR POR CATEGORIA

        public List<Cursos> Categoria1()
        {
            using (db = new DBConnection())
            {
                var strQuery = string.Format("SELECT * FROM Curso WHERE Id_Categoria = 1;");
                var retorno = db.RetornaComando(strQuery);
                return BuscaCategoria1(retorno);
            }

        }

        public List<Cursos> BuscaCategoria1(SqlDataReader retorno)
        {
            var cursos= new List<Cursos>();

            while (retorno.Read())
            {
                var TempCurso = new Cursos()
                {
                    Nome = retorno["Nome"].ToString(),
                    Desc_cur = retorno["Desc_cur"].ToString(),
                    Id_Categoria = int.Parse(retorno["Id_Categoria"].ToString()),
                    Id_Curso = int.Parse(retorno["Id_Curso"].ToString()),
                    Aula1 = retorno["Aula1"].ToString(),
                    Aula2 = retorno["Aula2"].ToString(),
                    Aula3 = retorno["Aula3"].ToString(),
                    Aula4 = retorno["Aula4"].ToString(),
                    Aula5 = retorno["Aula5"].ToString(),
                    Aula6 = retorno["Aula6"].ToString(),
                    Aula7 = retorno["Aula7"].ToString(),
                    Aula8 = retorno["Aula8"].ToString(),
                    Aula9 = retorno["Aula9"].ToString(),
                    Aula10 = retorno["Aula10"].ToString(),
                };
                cursos.Add(TempCurso);
            }
            retorno.Close();
            return cursos;
        }

        public List<Cursos> Categoria2()
        {
            using (db = new DBConnection())
            {
                var strQuery = string.Format("SELECT * FROM Curso WHERE Id_Categoria = 2;");
                var retorno = db.RetornaComando(strQuery);
                return BuscaCategoria2(retorno);
            }

        }

        public List<Cursos> BuscaCategoria2(SqlDataReader retorno)
        {
            var cursos = new List<Cursos>();

            while (retorno.Read())
            {
                var TempCurso = new Cursos()
                {
                    Nome = retorno["Nome"].ToString(),
                    Desc_cur = retorno["Desc_cur"].ToString(),
                    Id_Categoria = int.Parse(retorno["Id_Categoria"].ToString()),
                    Id_Curso = int.Parse(retorno["Id_Curso"].ToString()),
                    Aula1 = retorno["Aula1"].ToString(),
                    Aula2 = retorno["Aula2"].ToString(),
                    Aula3 = retorno["Aula3"].ToString(),
                    Aula4 = retorno["Aula4"].ToString(),
                    Aula5 = retorno["Aula5"].ToString(),
                    Aula6 = retorno["Aula6"].ToString(),
                    Aula7 = retorno["Aula7"].ToString(),
                    Aula8 = retorno["Aula8"].ToString(),
                    Aula9 = retorno["Aula9"].ToString(),
                    Aula10 = retorno["Aula10"].ToString(),
                };
                cursos.Add(TempCurso);
            }
            retorno.Close();
            return cursos;
        }




    }
}