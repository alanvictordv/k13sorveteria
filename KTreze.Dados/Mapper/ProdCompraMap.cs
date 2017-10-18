//using FluentNHibernate.Mapping;
//using KTreze.Dados.Entidades;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KTreze.Dados.Mapper
//{
//    public class ProdCompraMap : ClassMap<ProdCompra>
//    {
//        public ProdCompraMap()
//        {
//            Table("prodcompra");
//            CompositeId()
//            .KeyReference(p => p.Produto, "id_prod")
//            .KeyReference(p => p.Compra, "id_compra");

//            Map(p => p.Quantidade, "quantidade").Not.Nullable();

//            References(p => p.Produto).Column("id_prod");
//            References(p => p.Compra).Column("id_compra");

//            //    public class TestChildMap : ClassMap<TestChild>
//            //{
//            //    public TestChildMap()
//            //    {
//            //        Table("TestChild");
//            //        CompositeId()
//            //            .KeyProperty(x => x.ChildName, "ChildName")
//            //            .KeyReference(x => x.Parent, "TestParentId");

//            //        Map(x => x.Age);
//            //        References(x => x.Parent, "TestParentId")
//            //            .Not.Insert();  //  will avoid "Index was out of range" error on insert
//            //    }
//            //}
//        }
//    }
//}
