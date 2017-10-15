using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using KTreze.Dados.Mapper;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Util
{
    /// <summary>
    /// Classe para configuração da SessionFactory
    /// </summary>
    public class HibernateUtil
    {
        private static ISessionFactory factory; //null
        public static ISessionFactory GetSessionFactory()
        {
            if (factory == null) //singleton...
            {
                factory = Fluently.Configure().Database(
                MsSqlConfiguration.MsSql2008.ConnectionString(
                ConfigurationManager.ConnectionStrings
                ["banco"].ConnectionString

                )
                ).Mappings(m => m.FluentMappings.
                AddFromAssemblyOf<ProdutoMap>()).

                BuildSessionFactory();
            }
            return factory;
        }
    }
}