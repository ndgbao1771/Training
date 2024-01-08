using AutoMapper;
using Training.Model;
using Training.Repository.Interfaces;
using Training.Service.Interfaces;
using Training.Service.ViewModel;

namespace Training.Service.Implement
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoService(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public TodoViewModel Add(TodoViewModel todoViewModel)
        {
            var datas = _mapper.Map<TodoViewModel, TodoModel>(todoViewModel);
            _todoRepository.Add(datas);
            _todoRepository.Commit();
            return todoViewModel;
        }

        public void Delete(int id)
        {
            _todoRepository.Delete(id);
            _todoRepository.Commit();
        }

        public List<TodoViewModel> GetAll()
        {
            List<TodoModel> datas = _todoRepository.FindAll().ToList();
            List<TodoViewModel> todoViewModels = _mapper.Map<List<TodoModel>, List<TodoViewModel>>(datas);
            return todoViewModels;
        }

        public TodoViewModel GetById(int id)
        {
            return _mapper.Map<TodoModel, TodoViewModel>(_todoRepository.FindById(id));
        }

        public void Save()
        {
            _todoRepository.Commit();
        }

        public void Update(TodoViewModel todoViewModel)
        {
            TodoModel datas = _todoRepository.FindById(todoViewModel.Id);
            if(datas != null)
            {
                datas.Name = todoViewModel.Name;
                datas.Description = todoViewModel.Description;
            }
            _todoRepository.Commit();
        }
    }
}