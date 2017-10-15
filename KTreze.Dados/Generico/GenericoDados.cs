using KTreze.Dados.Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTreze.Dados.Generico
{
    /// <summary>
    /// Classe genérica para persistência de objetos
    /// </summary>
    /// <typeparam name="T">Objeto a ser persisitdo</typeparam>
    /// <typeparam name="K">Identificador de objeto</typeparam>
    public class GenericoDados<T, K>
        where T : class
    {
        /// <summary>
        /// Implementação do método genérico para persistência de objeto em banco
        /// </summary>
        /// <param name="obj">Modelo para persistência</param>
        public void Inserir(T obj)
        {
            using (ISession sessao = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction transacao = sessao.BeginTransaction();
                Inserir(sessao, obj);
                transacao.Commit();
            }
        }

        /// <summary>
        /// Implementação do método genérico para persistência de objeto em banco
        /// </summary>
        /// <param name="sessao">ISession do Nhibernate</param>
        /// <param name="obj">Modelo para persistência</param>
        public void Inserir(object sessao, T obj)
        {
            // transforma o objeto em uma ISession
            ISession Sessao = (ISession)sessao;
            Sessao.Save(obj);
        }

        /// <summary>
        /// Implementação do método genérico para exclusão de objeto em banco
        /// </summary>
        /// <param name="obj">Modelo a ser excluído</param>
        public void Excluir(T obj)
        {
            using (ISession sessao = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction transacao = sessao.BeginTransaction();
                Excluir(sessao, obj);
                transacao.Commit();
            }
        }

        /// <summary>
        /// Implementação do método genérico para exclusão de objeto em banco
        /// </summary>
        /// <param name="sessao">ISession do Nhibernate</param>
        /// <param name="obj">Modelo a ser excluído</param>
        public void Excluir(object sessao, T obj)
        {
            // transforma o objeto em uma ISession
            ISession Sessao = (ISession)sessao;
            Sessao.Delete(obj);
        }

        /// <summary>
        /// Implementação do método genérico para alteração de informações de um objeto em banco
        /// </summary>
        /// <param name="obj">Modelo a ser alterado</param>
        public void Alterar(T obj)
        {
            using (ISession sessao = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction transacao = sessao.BeginTransaction();
                Alterar(sessao, obj);
                transacao.Commit();
            }
        }


        /// <summary>
        /// Implementação do método genérico para alteração de informações de um objeto em banco
        /// </summary>
        /// <param name="sessao">ISession do Nhibernate</param>
        /// <param name="obj">Modelo a ser alterado</param>
        public void Alterar(object sessao, T obj)
        {
            // transforma o objeto em uma ISession
            ISession Sessao = (ISession)sessao;
            Sessao.Update(obj);
        }

        /// <summary>
        /// Implementação do método genérico para listar todos as informações de uma consulta do banco
        /// </summary>
        public ICollection<T> ListarTodos()
        {
            using (ISession sessao = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return ListarTodos(sessao);
            }
        }

        /// <summary>
        /// Implementação do método genérico para listar todos as informações de uma consulta do banco
        /// </summary>
        /// <param name="sessao">ISession do Nhibernate</param>
        /// <returns>Lista do Objeto T</returns>
        public ICollection<T> ListarTodos(object sessao)
        {
            // transforma o objeto em uma ISession
            ISession Sessao = (ISession)sessao;

            var query = from obj in Sessao.Query<T>()
                        select obj;
            return query.ToList();
        }


        /// <summary>
        /// Implementação do método genérico para listar todas as informaçõed de uma consulta específica do banco
        /// </summary>
        /// <param name="id">Identificador do registro</param>
        /// <returns></returns>
        public T ObterPorId(K id)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return ObterPorId(s, id);
            }
        }

        /// <summary>
        /// Implementação do método genérico para listar todas as informaçõed de uma consulta específica do banco
        /// </summary>
        /// <param name="sessao">ISession do Nhibernate</param>
        /// <param name="id">Identificador do registro</param>
        /// <returns>Objeto T</returns>
        public T ObterPorId(object sessao, K id)
        {
            // transforma o objeto em uma ISession
            ISession Sessao = (ISession)sessao;
            return (T)Sessao.Get(typeof(T), id);
        }

        /// <summary>
        /// Implementação do método genérico para abrir uma sessão com o banco
        /// </summary>
        /// <returns>Retorna um ISection</returns>
        public object AbrirSessao()
        {
            return HibernateUtil.GetSessionFactory().OpenSession();
        }

        /// <summary>
        /// Implementação do método genérico para fechar uma Sessão
        /// </summary>
        /// <param name="sessao">Recebe uma ISection</param>
        public void FecharSessao(object sessao)
        {
            // transforma o objeto em uma ISession
            ISession Sessao = (ISession)sessao;
            // fecha a sessão
            Sessao.Close();
        }

        /// <summary>
        /// Implementação do método genérico para abrir uma transação
        /// </summary>
        /// <param name="sessao">Recebe uma ISection</param>
        /// <returns>Retorna uma ITransaction</returns>
        public object AbrirTransacao(object sessao)
        {
            // transforma o objeto em uma ISession
            ISession Sessao = (ISession)sessao;
            return Sessao.BeginTransaction();
        }

        /// <summary>
        /// Implementação do método genérico para commitar uma transação
        /// </summary>
        /// <param name="transacao">Recebe uma ITransaction</param>
        public void CommitarTransacao(object transacao)
        {
            // transforma o objeto em uma ITransaction
            ITransaction Transacao = (ITransaction)transacao;
            Transacao.Commit();
        }


        public void Rollback(object transacao)
        {
            // transforma o objeto em uma ITransaction
            ITransaction Transacao = (ITransaction)transacao;
            Transacao.Rollback();
        }

    }
}
