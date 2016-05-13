using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GL.CursoMvc.Domain.Interfaces.Repository
{
    //Essa classe será do tipo genérica
    public interface IRepository <TEntity> : IDisposable where TEntity : class
    {
        //Método Insert
        TEntity Adicionar(TEntity obj);

        //Método Select By Id
        TEntity ObterPorId(Guid id);

        //Método Select All
        IEnumerable<TEntity> ObterTodos();

        //Método Update
        TEntity Atualizar(TEntity obj);

        //Método Delete
        void Remover(Guid id);

        //Método para realizar uma busca Genérica. Ou seja, ele irá buscar qualquer coisa no nosso projeto
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        //Método para salvar as informações no EF. E ele é do tipo int porque ele grava a quantidade de linhas do BD
        int SaveChanges();
    }
}