using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace CadastroLogin.Models
{
    public class Cursos
    {
        public int Id_Curso { get; set; }

        [DisplayName("Categoria")]
        [Required]
        public string Id_Categoria { get; set; }

        [DisplayName("Nome do Curso")]
        [MinLength(5)]
        [Required(ErrorMessage = "O nome do curso é obrigatório!")]
        public string Nome { get; set; }

        [DisplayName("Descrição do curso")]
        [Required(ErrorMessage ="O curso deve ter uma breve descrição!")]
        public string Desc_cur { get; set; }

        [AllowHtml]
        [Required]
        [DisplayName("Aula 01")]
        public string Aula1 { get; set; }

        [AllowHtml]
        [DisplayName("Aula 02")]
        public string Aula2 { get; set; }

        [AllowHtml]
        [DisplayName("Aula 03")]
        public string Aula3 { get; set; }

        [AllowHtml]
        [DisplayName("Aula 04")]
        public string Aula4 { get; set; }

        [DisplayName("Aula 05")]
        public string Aula5 { get; set; }

        [DisplayName("Aula 06")]
        public string Aula6 { get; set; }

        [DisplayName("Aula 07")]
        public string Aula7 { get; set; }

        [DisplayName("Aula 08")]
        public string Aula8 { get; set; }

        [DisplayName("Aula 09")]
        public string Aula9 { get; set; }

        [DisplayName("Aula 10")]
        public string Aula10 { get; set; }




    }
}