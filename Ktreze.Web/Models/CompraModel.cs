using KTreze.Dados.Entidades;
using KTreze.Dados.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ktreze.Web.Models
{
    public class CompraModel
    {
        public List<ProdutoDto> ListagemProdutosCompra { get; set; }

            public decimal? Acumulador()
        {
            decimal? num = 0;
            foreach (ProdutoDto p in ListagemProdutosCompra)
            {
                num += p.Produto.PrecoCompra * p.Quantidade;
            }
            return num;
        }
    }
}

public class CadastroCompraModel
{
    public int IdProduto { get; set; }

    public List<SelectListItem> ListaProduto
    {
        get
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            ProdutoDados pd = new ProdutoDados();

            foreach (Produto p in pd.ListarTodos())
            {
                SelectListItem item = new SelectListItem();
                item.Value = p.Id.ToString();
                item.Text = p.Nome;

                lista.Add(item);
            }
            return lista;
        }
    }

    public int Quantidade { get; set; }
}

public class ProdutoDto
{
    public Produto Produto { get; set; }

    public int Quantidade { get; set; }
}

public class CadastroArmazenamentoModel
{
    public int IdFreezer { get; set; }

    public List<SelectListItem> ListaFreezer
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