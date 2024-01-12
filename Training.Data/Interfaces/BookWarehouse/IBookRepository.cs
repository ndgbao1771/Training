using Training.Model.Entities;

namespace Training.Repository.Interfaces.BookWarehouse
{
    public interface IBookRepository : IRepository<Book>
    {
        IQueryable<Book> GetAllInfo(string? keyword);
    }
}