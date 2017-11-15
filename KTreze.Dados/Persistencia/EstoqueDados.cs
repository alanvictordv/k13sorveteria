using KTreze.Dados.Entidades;
using KTreze.Dados.Generico;
using KTreze.Dados.Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Persistencia
{
    public class EstoqueDados : GenericoDados<Estoque, Int32>
    {
        public List<Estoque> ObterFreezersPorProduto(int IdProd)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = from t in s.Query<Estoque>()
                            where t.Produto.Id == IdProd
                            select t;

                List<Estoque> lista = new List<Estoque>();

                foreach (var t in query.ToList())
                {
                    Estoque e = new Estoque();

                    e.Produto = t.Produto;
                    e.Freezer = t.Freezer;
                    e.Quantidade = t.Quantidade;

                    lista.Add(e);
                }
                return lista;
            }
        }
        public Estoque ObterPorIdComposto(int IdProd, int IdFreezer)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = s.Query<Estoque>()
                            .Where(p => p.Produto.Id == IdProd && p.Freezer.Id == IdFreezer)
                            .FirstOrDefault();

                return query;
            }
        }
    }
}
