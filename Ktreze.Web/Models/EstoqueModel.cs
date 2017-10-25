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
        public Produto Produto { get; set; }
        public Freezer Freezer { get; set; }
        public int Quantidade { get; set; }
    }
}