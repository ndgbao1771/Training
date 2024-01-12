using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;
using Training.Service.Interfaces;
using Training.Service.ViewModel.BookWarehouse;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Training.Service.Implement.BookWarehouse
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookDetailRepository _bookDetailRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public BookService(IBookRepository bookRepository, IBookDetailRepository bookDetailRepository, IMapper mapper, AppDbContext context)
        {
            _bookRepository = bookRepository;
            _bookDetailRepository = bookDetailRepository;
            _mapper = mapper;
            _context = context;
        }

        public BookViewUpdateModel Add(BookViewUpdateModel bookViewUpdateModel)
        {
            var dataView = _context.BookDetails.Where(x => x.Seri == bookViewUpdateModel.Seri).FirstOrDefault();
            if (dataView != null)
            {
                return bookViewUpdateModel;
            }
            else
            {
                var datas = _mapper.Map<BookViewUpdateModel, Book>(bookViewUpdateModel);
                Book b = new Book()
                {
                    Name = bookViewUpdateModel.Name,
                    CreatedAt = DateTime.Now,
                    CreatedBy = bookViewUpdateModel.CreatedBy,
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = bookViewUpdateModel.UpdatedBy,
                    AuthorId = bookViewUpdateModel.AuthorId,
                    BookCategoryId = bookViewUpdateModel.BookCategoryId,
                    bookDetails = new List<BookDetail>()
                    {
                        new BookDetail()
                        {
                            Seri = bookViewUpdateModel.Seri,
                            BookId = bookViewUpdateModel.Id
                        }
                    }
                };
                _bookRepository.Add(b);
                _bookRepository.Commit();
            }
            
            return bookViewUpdateModel;
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
            _bookRepository.Commit();
        }

        public List<BookViewModel> GetAll(string? keyword)
        {
            List<Book> datas = _bookRepository.GetAllInfo(keyword)
                                              .Include(x => x.bookDetails)
                                              .Include(x => x.author)
                                              .Include(x => x.bookCategory)
                                              .ToList();
            List<BookViewModel> dataView = new List<BookViewModel>();
            foreach (var data in datas)
            {
                var result = new BookViewModel()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Seri = data.bookDetails.Select(x => x.Seri).First(),
                    Author = data.author.Name,
                    BookCategory = data.bookCategory.Name,
                    CreatedAt = data.CreatedAt,
                    CreatedBy = data.CreatedBy,
                    UpdatedAt = data.UpdatedAt,
                    UpdatedBy = data.UpdatedBy
                };
                dataView.Add(result);
            };
            
            return dataView;
        }

        public BookViewModel GetById(int id)
        {
            Book datas = _bookRepository.FindById(id);
            Author author = _context.Authors.FirstOrDefault(a => a.Id == datas.AuthorId);
            BookCategory category = _context.BookCategories.FirstOrDefault(x => x.Id == datas.BookCategoryId);
            BookDetail bookDetail = _context.BookDetails.FirstOrDefault(x => x.BookId == datas.Id);
            BookViewModel bookViewModels = new BookViewModel()
            {
                Id = datas.Id,
                Name = datas.Name,
                Seri = bookDetail.Seri,
                CreatedAt = datas.CreatedAt,
                UpdatedAt = datas.UpdatedAt,
                CreatedBy = datas.CreatedBy,
                UpdatedBy = datas.UpdatedBy,
                Author = author.Name,
                BookCategory = category.Name
            };
            return bookViewModels;
        }

        public void Update(BookViewUpdateModel bookViewModel)
        {
            Book datas = _bookRepository.FindById(bookViewModel.Id);
            if (datas != null)
            {
                _bookRepository.Update(datas);
            }
            _bookRepository.Commit();
        }
    }
}