using Microsoft.EntityFrameworkCore;
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

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }
        public List<T> FindAll()
        {
            return _dbSet.ToList();
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