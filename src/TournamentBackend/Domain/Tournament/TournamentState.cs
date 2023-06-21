



[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TournamentState {
	Registration = 0,
	Finalized,
	Start,
	Completed
}
