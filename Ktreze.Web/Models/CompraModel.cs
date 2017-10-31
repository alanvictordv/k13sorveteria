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
        public List<Produto> ListagemProdutos { get; set; }
        public List<Produto> ListagemProdutosCompra
        {
            get; set;
        }
            public decimal? Acumulador()
        {
            decimal? num = 0;
            foreach (Produto p in ListagemProdutosCompra)
            {
                num += p.PrecoCompra;
            }
            return num;
        }
    }
}

public class CadastroCompraModel
{
    public List<SelectListItem> Freezer
    {
        get
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            FreezerDados fd = new FreezerDados();

            foreach (Freezer f in fd.ListarTodos())
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
