using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;

namespace Training.Repository.BookWarehouseRepository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }
    }
}