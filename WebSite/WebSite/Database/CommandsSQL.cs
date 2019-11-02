using WebSite.Models;
using WebSite.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebSite.Database
{
    public class CommandsSQL
    {
        private DBConnection db;

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
                    Login = retorno["Login_user"].ToString()
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }
 

    }
}