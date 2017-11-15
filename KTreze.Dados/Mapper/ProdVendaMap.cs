using FluentNHibernate.Mapping;
using KTreze.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Mapper
{
    public class ProdVendaMap : ClassMap<ProdVenda>
    {
        public ProdVendaMap()
        {
            Table("prodvenda");
            CompositeId()
            .KeyReference(p => p.Produto, "id_prod")
            .KeyReference(p => p.Venda, "id_venda");

            Map(p => p.Quantidade, "quantidade").Not.Nullable();

            References(p => p.Produto).Column("id_prod").Not.Insert();
            References(p => p.Venda).Column("id_venda").Not.Insert();
        }
    }
}
