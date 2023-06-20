using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class Child1EntityConfiguration : IEntityTypeConfiguration<Child1Entity>
{
    public void Configure(EntityTypeBuilder<Child1Entity> entityBuilder)
    {
        entityBuilder.HasBaseType<BaseEntity>();
        entityBuilder.OwnsOne(entity => entity.Data, builder =>
        {
            builder.ToTable("Child1EntityData");
            builder.HasKey(data => data.Id);
            builder.Property(data => data.Name);
            builder.WithOwner().HasForeignKey("Child1EntityId");
        });
    }
}
