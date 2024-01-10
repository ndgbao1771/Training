using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Interfaces
{
    public interface IBookCategoryService
    {
        List<BookCategoryViewModel> GetAll();

        BookCategoryViewModel GetById(int id);

        BookCategoryViewModel Add(BookCategoryViewModel bookCategoryViewModel);

        void Update(BookCategoryViewModel bookCategoryViewModel);

        void Delete(int id);
    }
}