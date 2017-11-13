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
    public class VendaController : Controller
    {
        public ActionResult InstanciaConsulta()
        {
            Session["ListaVenda"] = null;
            return RedirectToAction("ConsultaVenda");
        }
        public ActionResult ConsultaVenda()
        {
            VendaModel vm = new VendaModel();
            vm.ListagemProdutosVenda = (List<ProdutoDto>)Session["ListaVenda"];

            return View(vm);
        }
        public ActionResult AdicaoProduto()
        {
            return View(new CadastroVendaModel());
        }
        public ActionResult AdicionarProduto(CadastroVendaModel model)
        {
            List<ProdutoDto> listaProd = new List<ProdutoDto>();
            if (Session["ListaVenda"] != null)
                listaProd = (List<ProdutoDto>)Session["ListaVenda"];

            ProdutoDto pDto = new ProdutoDto();
            ProdutoDados pDados = new ProdutoDados();
            Produto p = pDados.ObterPorId(model.IdProduto);

            pDto.Produto = p;
            pDto.Quantidade = model.Quantidade;
            listaProd.Add(pDto);

            VendaModel vm = new VendaModel();
            vm.ListagemProdutosVenda = listaProd;
            Session["ListaVenda"] = listaProd;

            ModelState.Clear();
            ViewBag.MensagemCompra = "Produto adicionado à lista com sucesso.";

            return View("AdicaoProduto", new CadastroVendaModel());
        }
        public ActionResult Deletar(int id)
        {
            ProdutoDados pDados = new ProdutoDados();

            List<Produto> lista = (List<Produto>)pDados.ListarTodos();
            List<ProdutoDto> listaProd = new List<ProdutoDto>();

            if (Session["ListaVenda"] != null)
                listaProd = (List<ProdutoDto>)Session["ListaVenda"];

            listaProd.RemoveAll(x => x.Produto.Id == id);

            VendaModel vm = new VendaModel();
            vm.ListagemProdutosVenda = listaProd;

            Session["ListaVenda"] = vm.ListagemProdutosVenda;

            return View("ConsultaVenda", vm);
        }
        public ActionResult FinalizaVenda()
        {
            VendaModel vm = new VendaModel();
            vm.ListagemProdutosVenda = (List<ProdutoDto>)Session["ListaVenda"];

            Venda v = new Venda();
            v.Preco = vm.Acumulador();
            v.DataHora = DateTime.Now;

            VendaDados vd = new VendaDados();
            vd.Inserir(v);

            ProdVenda pv = new ProdVenda();
            ProdVendaDados pvDados = new ProdVendaDados();

            foreach (ProdutoDto p in vm.ListagemProdutosVenda)
            {
                pv.Venda = v;
                pv.Produto = p.Produto;
                pv.Quantidade = p.Quantidade;
                pvDados.Inserir(pv);
            }

            return RedirectToAction("ArmazenamentoVenda");
        }
        public ActionResult ArmazenamentoVenda()
        {
            if (Session["ListaVenda"] != null)
            {
                VendaModel vm = new VendaModel();
                vm.ListagemProdutosVenda = (List<ProdutoDto>)Session["ListaVenda"];

                return View(vm);
            }
            else
                return RedirectToAction("InstanciaConsulta");
        }
        public ActionResult SelecionaArmazenamentoVenda(int id)
        {
            ProdutoDados pDados = new ProdutoDados();
            Produto p = pDados.ObterPorId(id);
            List<ProdutoDto> lista = (List<ProdutoDto>)Session["ListaVenda"];
            ProdutoDto pDto = lista.Find(x => x.Produto.Id == p.Id);

            Session["ProdutoVenda"] = pDto;
            ViewBag.NomeProd = pDto.Produto.Nome.ToString();
            ViewBag.QuantProd = pDto.Quantidade.ToString();

            EstoqueDados eDados = new EstoqueDados();
            CadastroArmazenamentoVendaModel cam = new CadastroArmazenamentoVendaModel();
            
            List<SelectListItem> listaCombo = new List<SelectListItem>();

            List<Estoque> listaAux = cam.listarFreezerDisp(id);

            foreach (Estoque e in listaAux)
            {
                Estoque estAux = new Estoque();
                estAux.Freezer = e.Freezer;
                estAux.Produto = e.Produto;
                estAux.Quantidade = e.Quantidade;

                SelectListItem item = new SelectListItem();
                item.Value = estAux.Freezer.Id.ToString();
                item.Text = estAux.Freezer.Numeracao;
                listaCombo.Add(item);
            }

            cam.listaFreezerDisp = cam.listarFreezerDisp(id);
            cam.ListaFreezer = listaCombo;

            return View(cam);
        }
    }
}