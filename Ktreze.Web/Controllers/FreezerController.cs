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
    public class FreezerController : Controller
    {
        // GET: Estoque
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastroFreezer()
        {
            return View(new FreezerModel());
        }
        public ActionResult CadastrarFreezer(FreezerModel model)
        {
            try
            {
                FreezerDados fDados = new FreezerDados();
                Freezer freezer = new Freezer();
                freezer.Numeracao = model.Numeracao;
                freezer.Descricao = model.Descricao;

                fDados.Inserir(freezer);

                ViewBag.Mensagem = "Freezer cadastrado com sucesso.";
                ModelState.Clear();
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View("CadastroFreezer", new FreezerModel());
        }
        public ActionResult ConsultaFreezer()
        {
            FreezerDados fDados = new FreezerDados();

            List<FreezerModel> listfm = new List<FreezerModel>();
            List<Freezer> lista = (List<Freezer>)fDados.ListarTodos();

            foreach (Freezer f in lista)
            {
                FreezerModel fm = new FreezerModel();
                fm.Id = f.Id;
                fm.Numeracao = f.Numeracao;
                fm.Descricao = f.Descricao;

                listfm.Add(fm);
            }

            return View(listfm);
        }
        public ActionResult DeletarFreezer(int id)
        {
            FreezerDados fDados = new FreezerDados();
            Freezer f = fDados.ObterPorId(id);
            fDados.Excluir(f);

            return RedirectToAction("ConsultaFreezer");
        }
    }
}