namespace Domain.Match;

using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MatchState {
	Ready = 0,
	OpponentsRegistered,
	Started,
	InProgress,
	Completed
}


public sealed class Match {

    public Ulid Id { get; init; }

    public MatchState State { get; private set; } = MatchState.Ready;

    public DateTime Created { get; private set; }

    public DateTime? Started { get; private set; }

    public DateTime? Completed { get; private set; }

    public List<Ulid> AttachmentId { get; private set; }

    public Score Score { get; private set; }

    private Match(Ulid id, Score score) {
        Id = id;
        Score = score;
    }

    public static Match Create(Score score) {
        return new Match(Ulid.NewUlid(), score);
    }

}

