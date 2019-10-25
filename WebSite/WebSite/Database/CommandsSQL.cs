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



    }
}