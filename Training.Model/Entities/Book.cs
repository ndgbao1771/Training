using Training.Model.Shared;

namespace Training.Model.Entities
{
    public class Book : DomainEntity<int>, IDateTracking
    {
        public Book(string name, DateTime createdAt, string createdBy, DateTime updatedAt, string updatedBy)
        {
            Name = name;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
        public Book(string name, DateTime createdAt, string createdBy, DateTime updatedAt, string updatedBy, int authorId, int bookCategoryId)
        {
            Name = name;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            AuthorId = authorId;
            BookCategoryId = bookCategoryId;
        }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public int AuthorId { get; set; }
        public Author author { get; set; }

        public int BookCategoryId { get; set; }
        public BookCategory bookCategory { get; set;}

        public List<BookDetail> bookDetails { get; set; }
    }
}