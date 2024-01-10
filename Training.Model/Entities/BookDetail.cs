using Training.Model.Shared;

namespace Training.Model.Entities
{
    public class BookDetail : DomainEntity<int>
    {
        public BookDetail()
        {
        }

        public BookDetail(string seri) 
        {
            Seri = seri;
        }

        public string Seri { get; set; }
        public int BookId { get; set; }
        public Book book { get; set; }
    }
}