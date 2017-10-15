using FluentNHibernate.Mapping;
using KTreze.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Mapper
{
    public class CompraMap : ClassMap<Compra>
    {
        public CompraMap()
        {
            Table("compra");

            Id(p => p.Id, "id").GeneratedBy.Identity();

            Map(p => p.Preco, "preco").Not.Nullable();
            Map(p => p.DataHora, "data_hora").Not.Nullable();
        }
    }
}
