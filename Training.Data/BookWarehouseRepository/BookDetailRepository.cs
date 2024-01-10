using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;

namespace Training.Repository.BookWarehouseRepository
{
    public class BookDetailRepository : Repository<BookDetail>, IBookDetailRepository
    {
        public BookDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}