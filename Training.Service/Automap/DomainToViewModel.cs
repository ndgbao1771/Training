using AutoMapper;
using Training.Model;
using Training.Model.Entities;
using Training.Service.ViewModel;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Automap
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<TodoModel, TodoViewModel>();

            CreateMap<Book, BookViewModel>();
            CreateMap<Book, BookViewUpdateModel>();

            CreateMap<Author, AuthorViewModel>();

            CreateMap<BookCategory, BookCategoryViewModel>();

            CreateMap<BookDetail, BookDetailViewModel>();
        }
    }
}