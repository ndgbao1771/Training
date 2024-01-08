using Training.Model;
using Training.Repository.Interfaces;

namespace Training.Repository
{
    public class TodoRepository : Repository<TodoModel>, ITodoRepository
    {
        public TodoRepository(AppDbContext context) : base(context)
        {
        }
    }
}