using FluentNHibernate.Mapping;
using KTreze.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Mapper
{
    public class EstoqueMap : ClassMap<Estoque>
    {
        public EstoqueMap()
        {
            Table("estoque");
            CompositeId()
            .KeyReference(p => p.Produto, "id_prod")
            .KeyReference(p => p.Freezer, "id_freezer");

            Map(p => p.Quantidade, "quantidade").Not.Nullable();

            References(p => p.Produto).Column("id_prod").Not.Insert();
            References(p => p.Freezer).Column("id_freezer").Not.Insert();
        }
    }
}
