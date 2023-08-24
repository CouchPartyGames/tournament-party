namespace Domain.Abstractions;

public class Entity {

    Ulid Id { get; init; }

    public Entity(Ulid id) => Id = id;
}