namespace CouchParty.TournamentBackend.Models.DTO;

public sealed class CreateTournamentRequest {
	public string Name { get; set; }
	
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public Tournament.EliminationLevel Level { get; set; } = Tournament.EliminationLevel.Single;

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public Tournament.DrawType Type { get; set; }
}
