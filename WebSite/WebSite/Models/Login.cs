using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebSite.Models
{
    public class Login
    {
        //[DisplayName("Usuário")]
        [Required(ErrorMessage = "O Login é obrigatório")]
        public string User { get; set; }

        //[DisplayName("Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; }
    }
}