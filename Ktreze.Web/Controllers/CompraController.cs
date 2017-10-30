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
    public class CompraController : Controller
    {
        
        public static decimal? AcumulaPreco;

        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastroCompra()
        {
            return View();
        }
        public ActionResult CadastrarCompra()
        {
            try
            {

            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View();
        }

        public ActionResult InstanciaConsulta()
        {
            Session["Lista"] = null;
            return RedirectToAction("ConsultaCompra");
        }
        public ActionResult ConsultaCompra()
        {
            EstoqueDados eDados = new EstoqueDados();
            ProdutoDados pDados = new ProdutoDados();
            FreezerDados fDados = new FreezerDados();

            List<CompraModel> listcm = new List<CompraModel>();
            List<Produto> lista = (List<Produto>)pDados.ListarTodos();

            CompraModel cm = new CompraModel();
            cm.ListagemProdutos = lista;

            return View(cm);
        }

        public ActionResult SelecionarProduto(int id)
        {
            ProdutoDados pDados = new ProdutoDados();
            Produto p = pDados.ObterPorId(id);

            List<Produto> lista = (List<Produto>)pDados.ListarTodos();
            List<Produto> listaProd = new List<Produto>();

            if(Session["Lista"] != null)
            listaProd = (List<Produto>)Session["Lista"];

            listaProd.Add(p);

            CompraModel cm = new CompraModel();

            cm.ListagemProdutos = lista;
            cm.ListagemProdutosCompra = listaProd;

            Session["Lista"] = cm.ListagemProdutosCompra;

            return View("ConsultaCompra", cm);
        }
    }
}