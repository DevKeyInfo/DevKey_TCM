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
        [DisplayName("Tipo de usuário")]
        public string UserType { get; set; } 

        public int ID { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }

        [DisplayName("E-mail")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                            ErrorMessage = "Insira um e-mail válido")]
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        public string Email { get; set; }

        [DisplayName("Usuário")]
        [Required(ErrorMessage = "Campo obrigatório")]
        //[MinLength(6, ErrorMessage = "Seu login deve conter no mínimo 6 caracteres")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Sua senha deve conter no mínimo 6 caracteres")]
        public string Password { get; set; }

        [DisplayName("Confirme sua senha")]
        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Sua senha deve conter no mínimo 6 caracteres")]
        [Compare(nameof(Password), ErrorMessage ="Suas senhas devem ser iguais")]
        public string ConfirmPassword { get; set; }
    }
}