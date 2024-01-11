using AutoMapper;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Repository.BookWarehouseRepository
{
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository _librarianRepository;
        private readonly IMapper _mapper;

        public LibrarianService(ILibrarianRepository librarianRepository, IMapper mapper)
        {
            _librarianRepository = librarianRepository;
            _mapper = mapper;
        }

        public LibrarianViewModel Add(LibrarianViewModel librarianViewModel)
        {
            var datas = _librarianRepository.FindById(librarianViewModel.Id);
            if (datas != null)
            {
                throw new NotImplementedException();
            }
            else
            {
                var dataDomain = _mapper.Map<LibrarianViewModel, Librarian>(librarianViewModel);
                _librarianRepository.Add(dataDomain);
                _librarianRepository.Commit();
            }
            return librarianViewModel;
        }

        public void Delete(int id)
        {
            _librarianRepository.Delete(id);
            _librarianRepository.Commit();
        }

        public List<LibrarianViewModel> GetAll()
        {
            List<Librarian> datas = _librarianRepository.FindAll();
            List<LibrarianViewModel> dataViewModel = _mapper.Map<List<Librarian>, List<LibrarianViewModel>>(datas);
            return dataViewModel;
        }

        public List<LibrarianViewModel> GetAllByName(string keyword)
        {
            List<Librarian> datas = _librarianRepository.GetAllByName(keyword);
            List<LibrarianViewModel> dataViewModel = _mapper.Map<List<Librarian>, List<LibrarianViewModel>>(datas);
            return dataViewModel;
        }

        public void Update(LibrarianViewModel librarianViewModel)
        {
            var dataDomain = _mapper.Map<LibrarianViewModel, Librarian>(librarianViewModel);
            _librarianRepository.Update(dataDomain);
            _librarianRepository.Commit();
        }
    }
}