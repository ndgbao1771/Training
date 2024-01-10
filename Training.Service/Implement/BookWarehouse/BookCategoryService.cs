using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;
using Training.Service.Interfaces;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Implement.BookWarehouse
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;
        private readonly IMapper _mapper;

        public BookCategoryService(IBookCategoryRepository bookCategoryRepository, IMapper mapper)
        {
            _bookCategoryRepository = bookCategoryRepository;
            _mapper = mapper;
        }

        public BookCategoryViewModel Add(BookCategoryViewModel bookCategoryViewModel)
        {
            var datas = _mapper.Map<BookCategoryViewModel, BookCategory>(bookCategoryViewModel);
            _bookCategoryRepository.Add(datas);
            _bookCategoryRepository.Commit();
            return bookCategoryViewModel;
        }

        public void Delete(int id)
        {
            _bookCategoryRepository.Delete(id);
            _bookCategoryRepository.Commit();
        }

        public List<BookCategoryViewModel> GetAll()
        {
            List<BookCategory> datas = _bookCategoryRepository.FindAll();
            List<BookCategoryViewModel> dataView = _mapper.Map<List<BookCategory>, List<BookCategoryViewModel>>(datas);
            return dataView;
        }

        public BookCategoryViewModel GetById(int id)
        {
            BookCategory datas = _bookCategoryRepository.FindById(id);
            BookCategoryViewModel dataView = _mapper.Map<BookCategory, BookCategoryViewModel>(datas);
            return dataView;
        }

        public void Update(BookCategoryViewModel bookCategoryViewModel)
        {
            BookCategory datas = _bookCategoryRepository.FindById(bookCategoryViewModel.Id);
            if(datas != null)
            {
                _bookCategoryRepository.Update(datas);
            }
            else
            {
                throw new NotImplementedException();
            }
            _bookCategoryRepository.Commit();
        }
    }
}
