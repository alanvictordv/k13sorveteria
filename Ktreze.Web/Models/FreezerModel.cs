using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ktreze.Web.Models
{
    public class FreezerModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Numeração do freezer.")]
        [Display(Name = "Numeração: ")]
        public string Numeracao { get; set; }
        [Required(ErrorMessage = "Por favor, informe a descrição do freezer.")]
        [Display(Name = "Descrição: ")]
        public string Descricao { get; set; }
    }
}