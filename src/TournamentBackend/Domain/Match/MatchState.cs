namespace CouchParty.TournamentBackend.Enums;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MatchState {
	Ready = 0,
	OpponentsRegistered,
	Started,
	InProgress,
	Completed
}
