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
            StrQuery += string.Format("VALUES('{0}', '{1}', '{2}')", user.Name, user.Login, Hash.GerarHash(user.Password));

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
                    ID = retorno["Id_User"].ToString(),
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
        //Retorna lista de cursos cadastrados
        public List<Cursos> ListarCursos()
        {
            var db = new DBConnection();
            var strQuery = "SELECT * FROM vw_Cursos;";
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
                    Desc_cur = retorno["Descrição do curso"].ToString(),
                    Id_Categoria = retorno["Categoria"].ToString(),
                    //Aula1 = retorno["Aula 01"].ToString(),
                    //Aula2 = retorno["Aula 02"].ToString(),
                    //Aula3 = retorno["Aula 03"].ToString(),
                    //Aula4 = retorno["Aula 04"].ToString(),
                    //Aula5 = retorno["Aula 05"].ToString(),
                    //Aula6 = retorno["Aula 06"].ToString(),
                    //Aula7 = retorno["Aula 07"].ToString(),
                    //Aula8 = retorno["Aula 08"].ToString(),
                    //Aula9 = retorno["Aula 09"].ToString(),
                    //Aula10 = retorno["Aula 10"].ToString(),
                };
                cursos.Add(TempCurso);
            }
            retorno.Close();
            return cursos;
        }



        //Validação de login no banco de dados
        public Login ValidarLogin(Login login)
        {
            using (db = new DBConnection())
            {
                var strQuery = string.Format("SELECT * FROM tb_User WHERE Login_user = '{0}' AND Password_user = '{1}';", login.User, Hash.GerarHash(login.Password));
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
                    User = retorno["Login_user"].ToString(),
                    Password = retorno["Password_user"].ToString()
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }



        //Verifica se o usuario ja existe no banco de dados
        //public User ValidarCadastro(User user)
        //{
        //    using (db = new DBConnection())
        //    {
        //        var strQuery = string.Format("SELECT * FROM tb_User WHERE Login_user = '{0}';", user.Login);
        //        var retorno = db.RetornaComando(strQuery);
        //        return VerificarCadastro(retorno).FirstOrDefault();
        //    }

        //}

        //public List<User> VerificarCadastro(SqlDataReader retorno)
        //{
        //    var usuarios = new List<User>();

        //    while (retorno.Read())
        //    {
        //        var TempUsuario = new User()
        //        {
        //            Login = retorno["Login_user"].ToString()
        //        };
        //        usuarios.Add(TempUsuario);
        //    }
        //    retorno.Close();
        //    return usuarios;
        //}
 

    }
}