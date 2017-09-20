using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Generico
{
    public abstract class GenericoDados<T, K>
        where T : class
        where K : struct
    {
        public void Delete(T obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Delete(obj);
                t.Commit();
            }
        }

        public T Find(int Id)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return (T)s.Get(typeof(T), Id);
            }
        }

        public ICollection<T> FindAll()
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = from obj in s.Query<T>()
                            select obj;

                return query.ToList();
            }
        }

        public void Insert(T obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Save(obj);
                t.Commit();
            }
        }

        public void Update(T obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Update(obj);
                t.Commit();
            }
        }
    }
}
