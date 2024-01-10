using Training.Model.Shared;

namespace Training.Model.Entities
{
    public class Order : DomainEntity<int>
    {
        public int MemberId { get; set; }
        public Member member { get; set; }
        public int LibrarianId { get; set; }
        public Librarian librarian { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}