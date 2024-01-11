namespace Training.Service.ViewModel.BookWarehouse
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime DateGiveExpect { get; set; }
        public DateTime DateGiveCurrent { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
    }
}