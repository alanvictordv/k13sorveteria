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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CadastroProduto()
        {
            return View(new ProdutoModel());
        }
        public ActionResult CadastrarProduto(ProdutoModel model)
        {
            try
            {
                var pDados = new ProdutoDados();
                var prod = new Produto();
                prod.Codigo = model.Codigo;
                prod.Nome = model.Nome;
                prod.PrecoCompra = model.PrecoCompra;
                prod.PrecoVenda = model.PrecoVenda;
                prod.PontoReposicao = model.PontoReposicao;

                pDados.Inserir(prod);

                ViewBag.Mensagem = "Produto cadastrado com sucesso.";
                ModelState.Clear();
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View("CadastroProduto", new ProdutoModel());
        }
        public ActionResult ConsultaProduto()
        {
            ProdutoDados pDados = new ProdutoDados();

            List<ProdutoModel> listpm = new List<ProdutoModel>();
            List<Produto> lista = (List<Produto>)pDados.ListarTodos();
            
            foreach(Produto p in lista)
            {
                ProdutoModel pm = new ProdutoModel();
                pm.Id = p.Id;
                pm.Codigo = p.Codigo;
                pm.Nome = p.Nome;
                pm.PrecoCompra = p.PrecoCompra;
                pm.PrecoVenda = p.PrecoVenda;
                pm.PontoReposicao = p.PontoReposicao;

                listpm.Add(pm);
            }

            return View(listpm);
        }
        public ActionResult DeletarProduto(int id)
        {
            List<Estoque> listaEst = new EstoqueDados().ObterFreezersPorProduto(id);
            ProdutoDados pDados = new ProdutoDados();

            foreach (Estoque e in listaEst)
            {
                if(e.Quantidade == 0)
                {
                    new EstoqueDados().Excluir(e);
                }
                else
                {
                    ViewBag.MensagemErro = "Você não pode excluir um produto que tenha no estoque.";

                    List<ProdutoModel> listpm = new List<ProdutoModel>();
                    List<Produto> lista = (List<Produto>)pDados.ListarTodos();

                    foreach (Produto p in lista)
                    {
                        ProdutoModel pm = new ProdutoModel();
                        pm.Id = p.Id;
                        pm.Codigo = p.Codigo;
                        pm.Nome = p.Nome;
                        pm.PrecoCompra = p.PrecoCompra;
                        pm.PrecoVenda = p.PrecoVenda;
                        pm.PontoReposicao = p.PontoReposicao;

                        listpm.Add(pm);
                    }
                    return View("ConsultaProduto", listpm);
                }
            }
                Produto prod = pDados.ObterPorId(id);
                pDados.Excluir(prod);

            return RedirectToAction("ConsultaProduto");
        }
        public ActionResult ViewEdita(int id)
        {
            ProdutoDados pDados = new ProdutoDados();
            Produto p = pDados.ObterPorId(id);

            ProdutoModel model = new ProdutoModel();

            model.Id = p.Id;
            model.Codigo = p.Codigo;
            model.Nome = p.Nome;
            model.PrecoCompra = p.PrecoCompra;
            model.PrecoVenda = p.PrecoVenda;
            model.PontoReposicao = p.PontoReposicao;

            return View(model);
        }
        public ActionResult EditaProduto(ProdutoModel model)
        {
            try
            {
                ProdutoDados pDados = new ProdutoDados();
                Produto p = new Produto();

                p.Id = model.Id;
                p.Codigo = model.Codigo;
                p.Nome = model.Nome;
                p.PrecoCompra = model.PrecoCompra;
                p.PrecoVenda = model.PrecoVenda;
                p.PontoReposicao = model.PontoReposicao;

                pDados.Alterar(p);
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return RedirectToAction("ConsultaProduto");
        }
    }
}