using Training.Service.ViewModel;

namespace Training.Service.Interfaces
{
    public interface ITodoService
    {
        TodoViewModel Add(TodoViewModel todoViewModel);
        void Update(TodoViewModel todoViewModel);

        void Delete(int id);
        List<TodoViewModel> GetAll();  
        TodoViewModel GetById(int id);
        void Save();

    }
}