using Training.Model.Entities;

namespace Training.Repository.Interfaces.BookWarehouse
{
    public interface ILibrarianRepository : IRepository<Librarian>
    {
        List<Librarian> GetAllByName(string keyword);
    }
}