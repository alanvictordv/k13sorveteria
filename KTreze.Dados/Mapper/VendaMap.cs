using FluentNHibernate.Mapping;
using KTreze.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Mapper
{
    public class VendaMap : ClassMap<Venda>
    {
        public VendaMap()
        {
            Table("venda");

            Id(p => p.Id, "id_venda").GeneratedBy.Identity();

            Map(p => p.Preco, "preco").Not.Nullable();
            Map(p => p.Troco, "troco").Not.Nullable();
            Map(p => p.DataHora, "data_hora").Not.Nullable();

            HasMany(p => p.ProdVenda).KeyColumn("id_venda").Inverse();
        }
    }
}
