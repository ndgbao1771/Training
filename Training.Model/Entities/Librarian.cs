using Training.Model.Shared;

namespace Training.Model.Entities
{
    public class Librarian : DomainEntity<int>, IDateTracking
    {
        public Librarian(string name, DateTime createdAt, string createdBy, DateTime updatedAt, string updatedBy) 
        {
            Name = name;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public List<Order> orders { get; set; }
    }
}