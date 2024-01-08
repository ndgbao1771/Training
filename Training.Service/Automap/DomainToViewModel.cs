using AutoMapper;
using Training.Model;
using Training.Service.ViewModel;

namespace Training.Service.Automap
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<TodoModel, TodoViewModel>();
        }
    }
}