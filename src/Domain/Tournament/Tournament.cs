namespace Domain.Tournament;

public enum State {
    Registration,
    Completed
}

public sealed class Tournament {
    public Ulid Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public int MinParticipants { get; private set; }

    public int MaxParticipants { get; private set; }

    public Ulid GameId { get; private set; }

    public Ulid LocationId { get; private set; }

}
