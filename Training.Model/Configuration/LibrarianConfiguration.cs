using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.Model.Entities;

namespace Training.Model.Configuration
{
    public class LibrarianConfiguration : IEntityTypeConfiguration<Librarian>
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
            builder.ToTable("Libratians");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);

            builder.HasMany(x => x.orders).WithOne(x => x.librarian).HasForeignKey(x => x.LibrarianId);
        }
    }
}