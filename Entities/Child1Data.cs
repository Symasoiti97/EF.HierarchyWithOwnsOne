namespace Entities;

public sealed class Child1Data
{
    public Child1Data(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }
}
