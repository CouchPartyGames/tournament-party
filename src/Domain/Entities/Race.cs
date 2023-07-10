namespace Domain.Entities;

public sealed class Race
{
    Ulid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }

    private Race(Ulid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public static Race Create(Ulid id, string name, string description)
    {
        return new Race(id, name, description);
    }

}
