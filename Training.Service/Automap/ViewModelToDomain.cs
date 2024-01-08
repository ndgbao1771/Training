using AutoMapper;
using Training.Model;
using Training.Service.ViewModel;

namespace Training.Service.Automap
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<TodoViewModel, TodoModel>()
                .ConstructUsing(c => new TodoModel(c.Name, c.Description));
        }
    }
}