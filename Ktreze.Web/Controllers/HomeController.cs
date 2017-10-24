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
    }
}