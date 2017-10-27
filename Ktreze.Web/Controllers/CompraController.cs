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
        List<CompraModel> listaCompraModel = new List<CompraModel>();
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

        public ActionResult ConsultaCompra()
        {
            EstoqueDados eDados = new EstoqueDados();
            ProdutoDados pDados = new ProdutoDados();
            FreezerDados fDados = new FreezerDados();

            List<CompraModel> listcm = new List<CompraModel>();
            List<Produto> lista = (List<Produto>)pDados.ListarTodos();

            foreach (Produto p in lista)
            {
                CompraModel cm = new CompraModel();

                cm.CodProd = p.Codigo;
                cm.NomeProd = p.Nome;
                cm.PrecoCompra = p.PrecoCompra;

                listcm.Add(cm);
            }

            return View(listcm);
        }

        public ActionResult ConsultaListaCompra(int id)
        {
            ProdutoDados pDados = new ProdutoDados();
            Produto p = pDados.ObterPorId(id);
            CompraModel cm = new CompraModel();

            foreach (CompraModel item in listaCompraModel)
            {
                AcumulaPreco += item.PrecoCompra;
            }

            cm.CodProd = p.Codigo;
            cm.NomeProd = p.Nome;
            cm.PrecoCompra = p.PrecoCompra;

            return View();
        }

    }
}