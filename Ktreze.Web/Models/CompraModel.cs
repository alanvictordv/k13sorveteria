using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ktreze.Web.Models
{
    public class CompraModel
    {
        public string CodProd { get; set; }
        public string NomeProd { get; set; }
        public decimal? PrecoCompra { get; set; }
    }

    public class CadastroCompraModel
    {
        //TODO: continuar daqui: COMPRAMODEL E COMPRACONTROLLER
        public string Freezer { get; set; }
        public int Quantidade { get; set; }

    }
}