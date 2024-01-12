using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;

namespace Training.Repository.BookWarehouseRepository
{
    public class LibrarianRepository : Repository<Librarian>, ILibrarianRepository
    {
        private readonly AppDbContext _context;

        public LibrarianRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Librarian> GetAllByName(string keyword)
        {
            return _context.Librarians.Where(x => x.Name.Contains(keyword));
        }
    }
}