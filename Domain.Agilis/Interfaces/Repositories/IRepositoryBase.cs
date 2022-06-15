using Domain.Agilis.Entities;
using System.Collections.Generic;

namespace Domain.Agilis.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        T GetById(int id, bool asNoTracking = true);
        IList<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        bool Delete(int id);
    }
}
