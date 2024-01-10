using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorViewModel> GetAll();

        AuthorViewModel GetById(int id);

        AuthorViewModel Add(AuthorViewModel authorViewModel);

        void Update(AuthorViewModel authorViewModel);

        void Delete(int id);
    }
}