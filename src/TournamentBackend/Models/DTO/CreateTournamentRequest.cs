namespace CouchParty.TournamentBackend.Models.DTO;

public sealed class CreateTournamentRequest {
	public string Name { get; set; }
	
	public EliminationLevel Level { get; set; } = EliminationLevel.Single;

	public DrawType Type { get; set; }
}
