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
            int QuantDisponivel;
            List<ProdutoDto> listaAux = new List<ProdutoDto>();
            QuantDisponivel = new EstoqueDados().ObterQuantidadePorId(model.IdProduto);
            if (Session["ListaVenda"] != null)
            {
                listaAux = (List<ProdutoDto>)Session["ListaVenda"];
                foreach (ProdutoDto pdto in listaAux)
                {
                    if (pdto.Produto.Id == model.IdProduto)
                        QuantDisponivel = QuantDisponivel - pdto.Quantidade;
                }
            }

            if (model.Quantidade > 0 && model.Quantidade <= QuantDisponivel)
            {
                List<ProdutoDto> listaProd = new List<ProdutoDto>();
                if (Session["ListaVenda"] != null)
                    listaProd = (List<ProdutoDto>)Session["ListaVenda"];
                List<ProdutoDto> listaProd2 = new List<ProdutoDto>();

                int cont = 0;
                foreach (ProdutoDto pdto in listaProd)
                {
                    if (pdto.Produto.Id == model.IdProduto)
                    {
                        cont++;
                        pdto.Quantidade += model.Quantidade;
                    }

                    listaProd2.Add(pdto);
                }

                if (cont == 0)
                {
                    ProdutoDto pDto = new ProdutoDto();
                    ProdutoDados pDados = new ProdutoDados();
                    Produto p = pDados.ObterPorId(model.IdProduto);

                    pDto.Produto = p;
                    pDto.Quantidade = model.Quantidade;
                    listaProd2.Add(pDto);
                }

                VendaModel vm = new VendaModel();
                vm.ListagemProdutosVenda = listaProd2;
                Session["ListaVenda"] = listaProd2;

                ModelState.Clear();
                ViewBag.MensagemVenda = "Produto adicionado à lista com sucesso.";
                ViewBag.MensagemVendaErro = null;
            }
            else
            {
                ModelState.Clear();
                ViewBag.MensagemVendaErro = "A quantidade digitada é inválida ou não está disponível no estoque.";
                ViewBag.MensagemVenda = null;
            }

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
            cam.listaFreezerDisp = cam.listarFreezerDisp(id);

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

            cam.ListaFreezer = listaCombo;

            return View(cam);
        }
        public ActionResult ArmazenaVenda(CadastroArmazenamentoVendaModel model)
        {
            if (model.Quantidade > 0)
            {
                ProdutoDto pDto = (ProdutoDto)Session["ProdutoVenda"];

                EstoqueDados eDados = new EstoqueDados();
                Estoque e = eDados.ObterPorIdComposto(pDto.Produto.Id, model.IdFreezer);

                if (e != null)
                {
                    if (model.Quantidade <= e.Quantidade)
                    {
                        if (model.Quantidade <= pDto.Quantidade)
                        {
                            e.Quantidade = e.Quantidade - model.Quantidade;
                            eDados.Alterar(e);

                            pDto.Quantidade = pDto.Quantidade - model.Quantidade;
                            Session["ProdutoVenda"] = pDto;

                            List<ProdutoDto> listaProd = (List<ProdutoDto>)Session["ListaVenda"];
                            List<ProdutoDto> listaProd2 = new List<ProdutoDto>();
                            Session["ListaVenda"] = null;
                            foreach (ProdutoDto p in listaProd)
                            {
                                if (p.Produto.Id != pDto.Produto.Id)
                                {
                                    listaProd2.Add(p);
                                }
                            }
                            if (pDto.Quantidade != 0)
                                listaProd2.Add(pDto);

                            Session["ListaVenda"] = listaProd2;
                        }
                        else
                        {
                            ViewBag.MensagemVenda = "A quantidade que você tentou retirar não condiz com a venda efetuada.";
                            if (Session["ListaVenda"] != null)
                            {
                                VendaModel vm = new VendaModel();
                                vm.ListagemProdutosVenda = (List<ProdutoDto>)Session["ListaVenda"];

                                return View("ArmazenamentoVenda", vm);
                            }
                        }
                    }
                    else
                    {
                        ViewBag.MensagemVenda = "A quantidade que você solicitou não está disponível no freezer selecionado.";
                        if (Session["ListaVenda"] != null)
                        {
                            VendaModel vm = new VendaModel();
                            vm.ListagemProdutosVenda = (List<ProdutoDto>)Session["ListaVenda"];

                            return View("ArmazenamentoVenda", vm);
                        }
                    }
                }
                else
                {
                    ViewBag.MensagemVenda = "Você deve preencher todo o formulário.";
                    if (Session["ListaVenda"] != null)
                    {
                        VendaModel vm = new VendaModel();
                        vm.ListagemProdutosVenda = (List<ProdutoDto>)Session["ListaVenda"];

                        return View("ArmazenamentoVenda", vm);
                    }
                }
            }
            else
            {
                ViewBag.MensagemVenda = "A quantidade digitada é inválida.";
                if (Session["ListaVenda"] != null)
                {
                    VendaModel vm = new VendaModel();
                    vm.ListagemProdutosVenda = (List<ProdutoDto>)Session["ListaVenda"];

                    return View("ArmazenamentoVenda", vm);
                }
            }
            if (Session["ListaVenda"] != null)
                return RedirectToAction("ArmazenamentoVenda");
            else
                return RedirectToAction("InstanciaConsulta");
        }
    }
}