using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class Child2EntityConfiguration : IEntityTypeConfiguration<Child2Entity>
{
    public void Configure(EntityTypeBuilder<Child2Entity> entityBuilder)
    {
        entityBuilder.HasBaseType<BaseEntity>();
    }
}
