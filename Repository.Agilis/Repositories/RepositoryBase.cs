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

        public T GetById(int id, bool asNoTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (asNoTracking)
                query = query.AsNoTracking();

            return query.Where(x => x.Active == true).FirstOrDefault(x => x.Id == id);
        }

        public IList<T> GetAll()
        {
            return _dbSet.Where(x => x.Active == true).ToList();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);

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
