using KTreze.Dados.Entidades;
using KTreze.Dados.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ktreze.Web.Models
{
    public class VendaModel
    {
        public List<ProdutoDto> ListagemProdutosVenda { get; set; }
        public decimal? Acumulador()
        {
            decimal? num = 0;
            foreach (ProdutoDto p in ListagemProdutosVenda)
            {
                num += p.Produto.PrecoVenda * p.Quantidade;
            }
            return num;
        }
    }
    public class CadastroVendaModel
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

    public class CadastroArmazenamentoVendaModel
    {
        public int IdFreezer { get; set; }

        public List<SelectListItem> ListaFreezer { get; set; }

        public List<Estoque> listFreezerDisp { get; set; }

        public int Quantidade { get; set; }
    }
}