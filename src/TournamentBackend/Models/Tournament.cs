namespace CouchParty.TournamentBackend.Models;


public sealed class Tournament {

	public enum EliminationLevel {
		Single = 0,
		Double,
		Triple
	}

	public enum DrawType {
		Seeded,
		Blind
	}

	public enum TournamentState {
		Registration,
		Finalized,
		Start,
		Completed
	}
	
	[Column(Order = 1)]
	public int Id { get; set; }

	[Required]
	[Column(TypeName = "varchar(25)", Order = 2)]
	public string Name { get; set; }

	public EliminationLevel Level { get; set; } = EliminationLevel.Single;

	public DrawType Type { get; set; }

	public TournamentState State { get; set; }

	public DateOnly Date { get; set; }

	public TimeOnly Time { get; set; }

	public int MinPlayers { get; set; }

	public int MaxPlayers { get; set; }
}
