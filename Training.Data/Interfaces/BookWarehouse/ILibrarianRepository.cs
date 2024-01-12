using Training.Model.Entities;

namespace Training.Repository.Interfaces.BookWarehouse
{
    public interface ILibrarianRepository : IRepository<Librarian>
    {
        IQueryable<Librarian> GetAllByName(string keyword);
    }
}