namespace Training.Service.ViewModel.BookWarehouse
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public int MemberId { get; set; }
        public string LibrarianName { get; set; }
        public int LibrarianId { get; set; }
        public DateTime DateGiveCurent { get; set; }
        public DateTime DateGiveExpect { get; set; }
        public List<OrderDetailViewModel> orderDetails { get; set; }
    }
}