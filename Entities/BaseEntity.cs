namespace Entities;

public abstract class BaseEntity
{
    protected BaseEntity(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }
}
