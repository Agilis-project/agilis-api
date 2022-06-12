using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Agilis.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly AgilisDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(AgilisDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T ObterPorId(int id, bool asNoTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (asNoTracking)
                query = query.AsNoTracking();

            return query.FirstOrDefault(x => x.Id == id);
        }

        public IList<T> ObterTodos()
        {
            return _dbSet.ToList();
        }

        public void Inserir(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Alterar(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public bool Deletar(int id)
        {
            var entity = ObterPorId(id);

            if (entity != null && entity.Active)
            {
                entity.Active = false;
                _dbSet.Update(entity);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
