using Domain.Agilis.Entities;
using System.Collections.Generic;

namespace Domain.Agilis.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        T ObterPorId(int id, bool asNoTracking = true);
        IList<T> ObterTodos();
        void Inserir(T entity);
        void Alterar(T entity);
        bool Deletar(int id);
    }
}
