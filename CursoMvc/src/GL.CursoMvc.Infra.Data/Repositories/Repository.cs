using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GL.CursoMvc.Domain.Interfaces.Repository;
using GL.CursoMvc.Infra.Data.Context;

namespace GL.CursoMvc.Infra.Data.Repositories
{
    /*Essa classe ela implementa o que escrevemos na classe de contrato contida na
     * camada Domain, onde criamos a classe Repository com os métodos do CRUD */
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //preciso fazer a referencia do nosso Contexto
        protected CursoMvcContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new CursoMvcContext();
            DbSet = Db.Set<TEntity>();
        }

        /* Esse método aqui está como 'virtual' para que possamos subscreve-los */
        public virtual TEntity Adicionar(TEntity obj)
        {
            var returnObj = DbSet.Add(obj);
            SaveChanges();

            return returnObj;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos() //(int t, int s)
        {
            //Se usa o 'Take' e o 'Skip' para podermos fazer a paginação em memória do SQL
            return DbSet.ToList(); //Take(s).Skip(s).ToList();
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();

            return obj;
        }

        public virtual void Remover(Guid id)
        {
            /* Aqui temos que achar primeiro o objeto para depois realizar a remoção do mesmo */
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            /* Estamos usando o Garbagge Collection quando ele for passar por aqui
             * ele irá remover da maneira mais rápido da pilha */
            GC.SuppressFinalize(this);
        }
    }
}