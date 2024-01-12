using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;

namespace Training.Repository.BookWarehouseRepository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Book> GetAllInfo(string? keyword)
        {
            var query = from book in _context.Books
                        join author in _context.Authors on book.AuthorId equals author.Id
                        join category in _context.BookCategories on book.BookCategoryId equals category.Id
                        select book ;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.author.Name.Contains(keyword) || x.bookCategory.Name.Contains(keyword));
            }
            return query;
        }
    }
}