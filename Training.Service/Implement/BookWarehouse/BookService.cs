using AutoMapper;
using System.Linq;
using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;
using Training.Service.Interfaces;
using Training.Service.ViewModel.BookWarehouse;

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

        public List<BookViewModel> GetAll()
        {
            List<Book> datas = _bookRepository.GetAllInfo();
            List<BookViewModel> bookViewModels = new List<BookViewModel>();
            foreach (var data in datas)
            {
                Author author = _context.Authors.FirstOrDefault(a => a.Id == data.AuthorId);
                BookCategory category = _context.BookCategories.FirstOrDefault(x => x.Id == data.BookCategoryId);
                BookDetail bookDetail = _context.BookDetails.FirstOrDefault(x => x.BookId == data.Id);
                BookViewModel viewModel = new BookViewModel
                {
                    Id = data.Id,
                    Name = data.Name,
                    Seri = bookDetail.Seri,
                    CreatedAt = data.CreatedAt,
                    UpdatedAt = data.UpdatedAt,
                    CreatedBy = data.CreatedBy,
                    UpdatedBy = data.UpdatedBy,
                    Author = author.Name,
                    BookCategory = category.Name
                };
                bookViewModels.Add(viewModel);
            }
            return bookViewModels;
        }

        public List<BookViewModel> GetByAuthor(string keyword)
        {
            List<Book> datas = _bookRepository.GetByAuthor(keyword);
            List<BookViewModel> bookViewModels = new List<BookViewModel>();
            if(datas != null)
            {
                foreach (var data in datas)
                {
                    var bookDetail = _context.BookDetails.Where(x => x.BookId == data.Id).FirstOrDefault();
                    Author author = _context.Authors.Where(x => x.Id == data.AuthorId).FirstOrDefault();
                    BookCategory category = _context.BookCategories.Where(x => x.Id == data.BookCategoryId).FirstOrDefault();
                    BookViewModel bookViewModel = new BookViewModel
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Seri = bookDetail.Seri,
                        CreatedAt = data.CreatedAt,
                        UpdatedAt = data.UpdatedAt,
                        CreatedBy = data.CreatedBy,
                        UpdatedBy = data.UpdatedBy,
                        Author = author.Name,
                        BookCategory = category.Name

                    };
                    bookViewModels.Add(bookViewModel);
                }
            }
            
            return bookViewModels.ToList();
        }
        public List<BookViewModel> GetByCate(string keyword)
        {
            List<Book> datas = _bookRepository.GetByCate(keyword);
            List<BookViewModel> bookViewModels = new List<BookViewModel>();
            if (datas != null)
            {
                foreach (var data in datas)
                {
                    var bookDetail = _context.BookDetails.Where(x => x.BookId == data.Id).FirstOrDefault();
                    Author author = _context.Authors.Where(x => x.Id == data.AuthorId).FirstOrDefault();
                    BookCategory category = _context.BookCategories.Where(x => x.Id == data.BookCategoryId).FirstOrDefault();
                    BookViewModel bookViewModel = new BookViewModel
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Seri = bookDetail.Seri,
                        CreatedAt = data.CreatedAt,
                        UpdatedAt = data.UpdatedAt,
                        CreatedBy = data.CreatedBy,
                        UpdatedBy = data.UpdatedBy,
                        Author = author.Name,
                        BookCategory = category.Name

                    };
                    bookViewModels.Add(bookViewModel);
                }
            }

            return bookViewModels.ToList();
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