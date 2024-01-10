using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.Model.Entities;

namespace Training.Model.Configuration
{
    public class BookDetailConfiguration : IEntityTypeConfiguration<BookDetail>
    {
        public void Configure(EntityTypeBuilder<BookDetail> builder)
        {
            builder.ToTable("BookDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Seri).HasMaxLength(15).IsRequired();
        }
    }
}