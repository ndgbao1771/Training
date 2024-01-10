using AutoMapper;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;
using Training.Service.Interfaces;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Implement.BookWarehouse
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public AuthorViewModel Add(AuthorViewModel authorViewModel)
        {
            var datas = _mapper.Map<AuthorViewModel, Author>(authorViewModel);
            _authorRepository.Add(datas);
            _authorRepository.Commit();
            return authorViewModel;
        }

        public void Delete(int id)
        {
            _authorRepository.Delete(id);
        }

        public List<AuthorViewModel> GetAll()
        {
            List<Author> datas = _authorRepository.FindAll();
            List<AuthorViewModel> datasView = _mapper.Map<List<Author>, List<AuthorViewModel>>(datas);
            return datasView;
        }

        public AuthorViewModel GetById(int id)
        {
            Author datas = _authorRepository.FindById(id);
            AuthorViewModel datasView = _mapper.Map<Author, AuthorViewModel>(datas);
            return datasView;
        }

        public void Update(AuthorViewModel authorViewModel)
        {
            Author datas = _authorRepository.FindById(authorViewModel.Id);
            if(datas != null)
            {
                _authorRepository.Update(datas);
            }
            else
            {
                throw new NotImplementedException();
            }
            _authorRepository.Commit();
        }
    }
}