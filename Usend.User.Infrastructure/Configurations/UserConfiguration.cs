using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usend.UserApi.Domain.Entities;

namespace Usend.UserApi.Infrastructure.Configurations
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public virtual void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.Password);
            builder.Property(x => x.CPF);
            builder.Property(x => x.Email);
            builder.Property(x => x.Status);
            builder.Property(x => x.BirthDate);
            builder.HasIndex(p => new { p.Email, p.CPF }).IsUnique();
        }
    }
}
