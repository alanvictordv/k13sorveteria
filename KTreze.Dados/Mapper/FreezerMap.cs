//using FluentNHibernate.Mapping;
//using KTreze.Dados.Entidades;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KTreze.Dados.Mapper
//{
//    public class FreezerMap : ClassMap<Freezer>
//    {
//        public FreezerMap()
//        {
//            Table("freezer");

//            Id(p => p.Id, "id").GeneratedBy.Identity();

//            Map(p => p.Numeracao, "numeracao").Length(50).Not.Nullable();
//            Map(p => p.Descricao, "descricao").Length(50).Nullable();
//        }
//    }
//}
