using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public sealed class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
{
    public void Configure(EntityTypeBuilder<BaseEntity> entityBuilder)
    {
        entityBuilder.ToTable("Entities");
        entityBuilder.HasKey(entity => entity.Id);
        entityBuilder.Property(entity => entity.Name);
        entityBuilder.HasDiscriminator<string>("Discriminator")
            .HasValue<Child1Entity>("child1")
            .HasValue<Child2Entity>("child2");
    }
}
