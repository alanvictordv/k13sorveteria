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
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastroCompra(int id)
        {

            return View();
        }
        public ActionResult CadastrarCompra()
        {
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
    }
}