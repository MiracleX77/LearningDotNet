using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roller.Domain.Entities;

namespace Roller.Infrastructure.Database.Configuration
{
    public class RollConfiguration : IEntityTypeConfiguration<Roll>
    {
        public void Configure(EntityTypeBuilder<Roll> builder)
        {
            builder.ToTable("Rolls");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.Created).IsRequired();
        }
    }
}