using Ktreze.Web.Models;
using KTreze.Dados.Entidades;
using KTreze.Dados.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ktreze.Web.Controllers
{
    public class EstoqController : Controller
    {
        // GET: Estoq
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultaEstoque()
        {
            EstoqueDados eDados = new EstoqueDados();
            ProdutoDados pDados = new ProdutoDados();
            FreezerDados fDados = new FreezerDados();

            List<EstoqueModel> listem = new List<EstoqueModel>();
            List<Estoque> lista = (List<Estoque>)eDados.ListarTodos();

            foreach (Estoque e in lista)
            {
                if (e.Quantidade == 0)
                    eDados.Excluir(e);

                Produto p = pDados.ObterPorId(e.Produto.Id);
                Freezer f = fDados.ObterPorId(e.Freezer.Id);
                EstoqueModel em = new EstoqueModel();
                em.CodProduto = p.Codigo;
                em.NomeProduto = p.Nome;
                em.Freezer = f.Numeracao;
                em.DescFreezer = f.Descricao;
                em.Quantidade = e.Quantidade;

                listem.Add(em);
            }

            return View(listem);
        }
    }
}