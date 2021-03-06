﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ktreze.Web.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o código do processo.")]
        [Display(Name = "Código do produto: ")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        [Display(Name = "Nome do produto: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço de venda.")]
        [Display(Name = "Preço de venda: ")]
        public decimal? PrecoVenda { get; set; } = null;

        [Required(ErrorMessage = "Por favor, informe o preço de compra.")]
        [Display(Name = "Preço de compra:")] //label
        public decimal? PrecoCompra { get; set; } = null; //campo                  

        [Required(ErrorMessage = "Por favor, informe o ponto de reposição.")]
        [Display(Name = "Ponto de Reposição:")] //label
        public int PontoReposicao { get; set; } //campo    
    }
}