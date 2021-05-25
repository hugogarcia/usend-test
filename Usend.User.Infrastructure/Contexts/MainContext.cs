using Microsoft.EntityFrameworkCore;
using Usend.UserApi.Infrastructure.Configurations;

namespace Usend.UserApi.Infrastructure.Contexts
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
