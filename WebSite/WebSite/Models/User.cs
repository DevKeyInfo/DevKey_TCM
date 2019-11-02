using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebSite.Models
{
    public class User
    {
        public string UserType { get; set; } 

        public string ID { get; set; }

        //[DisplayName("Nome")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name { get; set; }

        //[DisplayName("E-mail")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Email { get; set; }

        //[DisplayName("Usuário")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(6, ErrorMessage = "Seu login deve conter no mínimo 6 caracteres")]
        public string Login { get; set; }

        //[DisplayName("Senha")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Sua senha deve conter no mínimo 6 caracteres")]
        public string Password { get; set; }

        //[DisplayName("Confirme sua senha")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Sua senha deve conter no mínimo 6 caracteres")]
        [Compare(nameof(Password), ErrorMessage ="Suas senhas devem ser iguais")]
        public string ConfirmPassword { get; set; }
    }
}