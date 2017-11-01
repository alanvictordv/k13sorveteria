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
        public string CodProduto { get; set; }
        public string NomeProduto { get; set; }
        public string Freezer { get; set; }
        public string DescFreezer { get; set; }
        public int Quantidade { get; set; }
    }
}