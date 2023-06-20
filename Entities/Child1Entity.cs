namespace Entities;

public sealed class Child1Entity : BaseEntity
{
    public Child1Entity(Guid id, string name) : base(id, name)
    {
    }

    public Child1Data Data { get; private set; } = null!;
}
