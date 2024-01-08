using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
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

    #region DesignTimeDbContextFactory

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private readonly IConfiguration _configuration;

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(_configuration.GetConnectionString("connection"));
            return new AppDbContext(builder.Options);
        }
    }

    #endregion DesignTimeDbContextFactory
}