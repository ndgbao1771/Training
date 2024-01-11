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

            CreateMap<Member, MemberViewModel>();

            CreateMap<Order, OrderViewModel>().ForMember(dest => dest.MemberName, otp => otp.MapFrom(x => x.member.Name))
                                              .ForMember(dest => dest.LibrarianName, otp => otp.MapFrom(x => x.librarian.Name));

            CreateMap<OrderDetail, OrderDetailViewModel>().ForMember(dest => dest.BookName, otp => otp.MapFrom(x => x.book.Name));

            CreateMap<Librarian, LibrarianViewModel>();
        }
    }
}