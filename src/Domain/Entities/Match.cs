namespace Domain.Entities;

public sealed class Match {

    Ulid Id { get; init; }

    public string Name { get; init; }

    private Match(Ulid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Match Create(Ulid id, string name)
    {
        return new Match(id, name);
    }

}

