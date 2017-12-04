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

        public decimal? AcumuladorPorProduto(ProdutoDto p)
        {
            return p.Produto.PrecoCompra * p.Quantidade;
        }
    }
}

public class CadastroCompraModel
{
    [Required(ErrorMessage = "Por favor, informe o produto.")]
    [Display(Name = "Produto: ")]
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
    [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
    [Display(Name = "Quantidade: ")]
    public int Quantidade { get; set; }
}

public class ProdutoDto
{
    [Required(ErrorMessage = "Por favor, informe o produto.")]
    [Display(Name = "Produto: ")]
    public Produto Produto { get; set; }

    [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
    [Display(Name = "Quantidade: ")]
    public int Quantidade { get; set; }
}

public class CadastroArmazenamentoModel
{
    [Required(ErrorMessage = "Por favor, informe o freezer.")]
    [Display(Name = "Freezer: ")]
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
    [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
    [Display(Name = "Quantidade: ")]
    public int Quantidade { get; set; }
}