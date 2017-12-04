using KTreze.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ktreze.Web.Models
{
    public class EstoqueModel
    {
        [Required(ErrorMessage = "Por favor, informe o código do produto.")]
        [Display(Name = "Código do produto: ")]
        public string CodProduto { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        [Display(Name = "nome do produto: ")]
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "Por favor, informe o número do freezer.")]
        [Display(Name = "Numeração do freezer: ")]
        public string Freezer { get; set; }
        [Required(ErrorMessage = "Por favor, informe a descrição do freezer.")]
        [Display(Name = "Descrição do freezer: ")]
        public string DescFreezer { get; set; }
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        [Display(Name = "Quantidade: ")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Por favor, informe o ponto de reposição.")]
        [Display(Name = "Ponto de reposição: ")]
        public int PontoReposicao { get; set; }
    }
    public class PontoModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        [Display(Name = "nome do produto: ")]
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        [Display(Name = "Quantidade: ")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Por favor, informe o ponto de reposição.")]
        [Display(Name = "Ponto de reposição: ")]
        public int PontoReposicao { get; set; }
        [Required(ErrorMessage = "Por favor, informe a quantidade de reposição.")]
        [Display(Name = "Quantidade de reposição: ")]
        public int QuantRepo { get; set; }
    }
}