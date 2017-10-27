using KTreze.Dados.Entidades;
using KTreze.Dados.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ktreze.Web.Models
{
    public class CompraModel
    {
        public string CodProd { get; set; }
        public string NomeProd { get; set; }
        public decimal? PrecoCompra { get; set; }
        public decimal? PrecoTotal { get; set; }
    }

    public class CadastroCompraModel
    {
        public List<SelectListItem> Freezer
        {
            get
            {
                List<SelectListItem> lista = new List<SelectListItem>();

                FreezerDados fd = new FreezerDados();

                foreach(Freezer f in fd.ListarTodos())
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = f.Id.ToString();
                    item.Text = f.Numeracao;

                    lista.Add(item);
                }
                return lista;
            }
        }

        public int Quantidade { get; set; }
    }
}