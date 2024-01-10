using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.Model.Entities;

namespace Training.Model.Configuration
{
    public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();

            builder.HasMany(x => x.books).WithOne(x => x.bookCategory).HasForeignKey(x => x.BookCategoryId);
        }
    }
}