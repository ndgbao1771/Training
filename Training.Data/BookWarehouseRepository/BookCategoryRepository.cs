using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;

namespace Training.Repository.BookWarehouseRepository
{
    public class BookCategoryRepository : Repository<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}