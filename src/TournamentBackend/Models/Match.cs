namespace CouchParty.TournamentBackend.Models;



public class Match {

	public enum MatchState {
		Ready,
		OpponentsRegistered,
		Started,
		InProgress,
		Completed
	}
	
	public int Id { get; set; }

	public MatchState State { get; set; }

	public DateTime Created { get; set; }
	public DateTime Started { get; set; }
	public DateTime Completed { get; set; }	
}
