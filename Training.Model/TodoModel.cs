using Training.Model.Shared;

namespace Training.Model
{
    public class TodoModel : DomainEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}