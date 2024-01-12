using Microsoft.EntityFrameworkCore;
using System.Linq;
using Training.Model;
using Training.Repository.Interfaces;

namespace Training.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);

        }
        public void Delete(int id)
        {
            Delete(FindById(id));
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }
        public IQueryable<T> FindAll()
        {
            IQueryable<T> item = _dbSet;
            return item;
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}