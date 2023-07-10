
namespace Domain.Entities;

public sealed class Template
{
    Ulid Id { get; init; }

    string Name { get; init; }

    public string Description { get; init; }

    private Template(Ulid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public static Template Create(Ulid id, string name, string description)
    {
        return new Template(id, name, description);
    }
}
