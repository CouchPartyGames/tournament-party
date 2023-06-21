namespace Domain.Match.Entities;

using Domain.Match.Enums;

public class Match {

    public int Id { get; private set; }

    public MatchState State { get; private set; } = MatchState.Ready;

    public DateTime Created { get; private set; }

    public DateTime Started { get; private set; }

    public DateTime Completed { get; private set; }
}
