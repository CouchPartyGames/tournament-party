namespace Domain.Match.Entities;

using Domain.Match.Enums;

public class Match {

    public int Id { get; set; }

    public MatchState State { get; set; }

    public DateTime Created { get; set; }

    public DateTime Started { get; set; }

    public DateTime Completed { get; set; }
}
