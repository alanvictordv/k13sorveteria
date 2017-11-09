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
            catch (Exception e)
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

            CompraModel cm = new CompraModel();
            cm.ListagemProdutosCompra = (List<ProdutoDto>)Session["Lista"];
            //cm.ListagemProdutos = lista;

            return View(cm);
        }

        public ActionResult AdicaoProduto()
        {
            return View(new CadastroCompraModel());
        }
        public ActionResult AdicionarProduto(CadastroCompraModel model)
        {
            List<ProdutoDto> listaProd = new List<ProdutoDto>();
            if (Session["Lista"] != null)
                listaProd = (List<ProdutoDto>)Session["Lista"];

            ProdutoDto pDto = new ProdutoDto();
            ProdutoDados pDados = new ProdutoDados();
            Produto p = pDados.ObterPorId(model.IdProduto);

            pDto.Produto = p;
            pDto.Quantidade = model.Quantidade;
            listaProd.Add(pDto);

            CompraModel cm = new CompraModel();
            cm.ListagemProdutosCompra = listaProd;
            Session["Lista"] = listaProd;

            ModelState.Clear();
            ViewBag.MensagemCompra = "Produto adicionado à lista com sucesso.";

            return View("AdicaoProduto", new CadastroCompraModel());
        }

        public ActionResult Deletar(int id)
        {
            ProdutoDados pDados = new ProdutoDados();
            //Produto p = pDados.ObterPorId(id);

            List<Produto> lista = (List<Produto>)pDados.ListarTodos();
            List<ProdutoDto> listaProd = new List<ProdutoDto>();
            List<ProdutoDto> listaProd2 = new List<ProdutoDto>();

            if (Session["Lista"] != null)
                listaProd = (List<ProdutoDto>)Session["Lista"];

            Session["Lista"] = null;

            foreach (ProdutoDto p in listaProd)
            {
                if (p.Produto.Id != id)
                {
                    listaProd2.Add(p);
                }
            }

            CompraModel cm = new CompraModel();

            //cm.ListagemProdutos = lista;
            cm.ListagemProdutosCompra = listaProd2;

            Session["Lista"] = cm.ListagemProdutosCompra;

            return View("ConsultaCompra", cm);
        }

        public ActionResult FinalizaCompra()
        {
            CompraModel cm = new CompraModel();
            cm.ListagemProdutosCompra = (List<ProdutoDto>)Session["Lista"];

            Compra c = new Compra();
            c.Preco = cm.Acumulador();
            c.DataHora = DateTime.Now;

            CompraDados cd = new CompraDados();
            cd.Inserir(c);

            ProdCompra pc = new ProdCompra();
            ProdCompraDados pcDados = new ProdCompraDados();

            foreach (ProdutoDto p in cm.ListagemProdutosCompra)
            {
                pc.Compra = c;
                pc.Produto = p.Produto;
                pc.Quantidade = p.Quantidade;
                pcDados.Inserir(pc);
            }

            return RedirectToAction("ArmazenamentoCompra");
        }
        public ActionResult ArmazenamentoCompra()
        {
            if (Session["Lista"] != null)
            {
                CompraModel cm = new CompraModel();
                cm.ListagemProdutosCompra = (List<ProdutoDto>)Session["Lista"];

                return View(cm);
            }
            else
                return RedirectToAction("InstanciaConsulta");
        }
        public ActionResult SelecionaArmazenamentoCompra(int id)
        {
            ProdutoDados pDados = new ProdutoDados();
            Produto p = pDados.ObterPorId(id);
            List<ProdutoDto> lista = (List<ProdutoDto>)Session["Lista"];
            ProdutoDto pDto = lista.Find(x => x.Produto.Id == p.Id);

            Session["Produto"] = pDto;
            ViewBag.NomeProd = pDto.Produto.Nome.ToString();
            ViewBag.QuantProd = pDto.Quantidade.ToString();

            return View(new CadastroArmazenamentoModel());
        }
        public ActionResult ArmazenaCompra(CadastroArmazenamentoModel model)
        {
            ProdutoDto pDto = (ProdutoDto)Session["Produto"];

            if (model.Quantidade <= pDto.Quantidade)
            {
                EstoqueDados eDados = new EstoqueDados();
                if (eDados.ObterPorIdComposto(pDto.Produto.Id, model.IdFreezer) != null)
                {
                    Estoque e = eDados.ObterPorIdComposto(pDto.Produto.Id, model.IdFreezer);
                    e.Quantidade += model.Quantidade;
                    eDados.Alterar(e);
                }
                else
                {
                    FreezerDados fDados = new FreezerDados();
                    Estoque e = new Estoque();
                    e.Produto = pDto.Produto;
                    e.Freezer = fDados.ObterPorId(model.IdFreezer);
                    e.Quantidade = model.Quantidade;
                    if(e.Produto != null && e.Freezer != null)
                    eDados.Inserir(e);
                    else
                    {
                        ViewBag.Mensagem = "Você deve preencher todo o formulário.";
                        if (Session["Lista"] != null)
                        {
                            CompraModel cm = new CompraModel();
                            cm.ListagemProdutosCompra = (List<ProdutoDto>)Session["Lista"];

                            return View("ArmazenamentoCompra", cm);
                        }
                    }
                }
                pDto.Quantidade = pDto.Quantidade - model.Quantidade;
                Session["Produto"] = pDto;

                List<ProdutoDto> listaProd = (List<ProdutoDto>)Session["Lista"];
                List<ProdutoDto> listaProd2 = new List<ProdutoDto>();
                Session["Lista"] = null;
                foreach (ProdutoDto p in listaProd)
                {
                    if (p.Produto.Id != pDto.Produto.Id)
                    {
                        listaProd2.Add(p);
                    }
                }
                if (pDto.Quantidade != 0)
                    listaProd2.Add(pDto);

                Session["Lista"] = listaProd2;
            }
            else
            {
                ViewBag.Mensagem = "A quantidade que você tentou inserir não condiz com a compra efetuada.";
                if (Session["Lista"] != null)
                {
                    CompraModel cm = new CompraModel();
                    cm.ListagemProdutosCompra = (List<ProdutoDto>)Session["Lista"];

                    return View("ArmazenamentoCompra", cm);
                }
            }
            if (Session["Lista"] != null)
                return RedirectToAction("ArmazenamentoCompra");
            else
                return RedirectToAction("InstanciaConsulta");
        }
    }
}