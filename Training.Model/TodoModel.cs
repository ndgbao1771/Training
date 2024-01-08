using Training.Model.Shared;

namespace Training.Model
{
    public class TodoModel : DomainEntity<int>
    {
        public TodoModel(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}