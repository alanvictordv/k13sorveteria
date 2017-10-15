using FluentNHibernate.Mapping;
using KTreze.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Mapper
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Table("produto");

            Id(p => p.Id, "id").GeneratedBy.Identity();

            Map(p => p.Codigo, "codigo").Length(50).Not.Nullable();
            Map(p => p.Nome, "nome").Length(50).Not.Nullable();
            Map(p => p.PrecoVenda, "preco_venda").Not.Nullable();
            Map(p => p.PrecoCompra, "preco_compra").Not.Nullable();
        }
    }
}
