using Microsoft.EntityFrameworkCore;
using Training.Model.Configuration;

namespace Training.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TodoModelConfiguration());
        }

        public DbSet<TodoModel> todoModels { get; set; }
    }
}