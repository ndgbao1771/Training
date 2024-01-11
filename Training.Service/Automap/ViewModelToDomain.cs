using AutoMapper;
using Training.Model;
using Training.Model.Entities;
using Training.Service.ViewModel;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Automap
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<TodoViewModel, TodoModel>()
                .ConstructUsing(c => new TodoModel(c.Name, c.Description));

            CreateMap<BookViewModel, Book>()
                .ConstructUsing(c => new Book(c.Name, c.CreatedAt, c.CreatedBy, c.UpdatedAt, c.UpdatedBy));

            CreateMap<BookViewUpdateModel, Book>()
                .ConstructUsing(c => new Book(c.Name, c.CreatedAt, c.CreatedBy, c.UpdatedAt, c.UpdatedBy, c.AuthorId, c.BookCategoryId));

            CreateMap<AuthorViewModel, Author>()
                .ConstructUsing(c => new Author(c.Name, c.CreatedAt, c.CreatedBy, c.UpdatedAt, c.UpdatedBy));

            CreateMap<BookCategoryViewModel, BookCategory>()
                .ConstructUsing(c => new BookCategory(c.Name, c.CreatedAt, c.CreatedBy, c.UpdatedAt, c.UpdatedBy));

            CreateMap<BookDetailViewModel, BookDetail>()
                .ConstructUsing(c => new BookDetail(c.Seri));

            CreateMap<MemberViewModel, Member>()
                .ConstructUsing(c => new Member(c.Name, c.CreatedAt, c.CreatedBy, c.UpdatedAt, c.UpdatedBy));

            CreateMap<OrderViewModel, Order>()
                .ConstructUsing(c => new Order(c.MemberId, c.LibrarianId));

            CreateMap<OrderDetailViewModel, OrderDetail>()
                .ConstructUsing(c => new OrderDetail(c.OrderId, c.BookId, c.DateGiveExpect, c.DateGiveCurrent));

            CreateMap<LibrarianViewModel, Librarian>()
               .ConstructUsing(c => new Librarian(c.Name, c.CreatedAt, c.CreatedBy, c.UpdatedAt, c.UpdatedBy));

        }
    }
}