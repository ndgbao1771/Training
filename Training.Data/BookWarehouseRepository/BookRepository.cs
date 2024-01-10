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

        public List<Book> GetAllInfo()
        {
            var query = from book in _context.Books
                        join bookDetail in _context.BookDetails on book.Id equals bookDetail.BookId
                        join author in _context.Authors on book.AuthorId equals author.Id
                        join category in _context.BookCategories on book.BookCategoryId equals category.Id
                        select book;
            return query.ToList();
        }
    }
}