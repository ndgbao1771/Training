using Training.Model.Shared;

namespace Training.Model.Entities
{
    public class Member : DomainEntity<int>, IDateTracking
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public List<Order> orders { get; set; }
    }
}