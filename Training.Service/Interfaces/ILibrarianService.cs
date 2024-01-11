using Training.Model.Entities;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Repository.Interfaces.BookWarehouse
{
    public interface ILibrarianService
    {
        List<LibrarianViewModel> GetAll();

        List<LibrarianViewModel> GetAllByName(string keyword);

        LibrarianViewModel Add(LibrarianViewModel librarianViewModel);

        void Update(LibrarianViewModel librarianViewModel);

        void Delete(int id);
    }
}