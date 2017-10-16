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
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View("CadastroProduto", new ProdutoModel());
        }
        //[Authorize]
        //public ActionResult Cadastro()
        //{
        //    return View(new ProcessoModel());
        //}
        //[Authorize]
        //public ActionResult Cadastrar(ProcessoModel model)
        //{
        //    try
        //    {
        //        pBusiness = new ProcessoBusiness();
        //        pBusiness.Service = new ProcessoData();

        //        cBusiness = new CategoriaBusiness();
        //        cBusiness.Service = new CategoriaData();

        //        Processo p = new Processo();
        //        p.numeroProcesso = model.NumeroProcesso;
        //        p.autor = model.Autor;
        //        p.reu = model.Reu;
        //        p.DataHoraInicio = model.DataHoraInicio;
        //        p.DataHoraFim = model.DataHoraFim;
        //        p.Categoria = cBusiness.Service.Find(model.IdCategoria);
        //        p.Usuario = (Usuario)Session["usuariologado"];

        //        pBusiness.CadastrarProcesso(p);

        //        ViewBag.Mensagem = "Processo cadastrado com sucesso.";
        //        ModelState.Clear();
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.Mensagem = e.Message;
        //    }
        //    return View("Cadastro", new ProcessoModel());
        //}
    }
}