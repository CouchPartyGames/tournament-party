namespace CouchParty.TournamentBackend.Models;


public sealed class Template {
	
	[Column(Order = 1)]
	public int Id { get; set; }

	[Required]
	[Column(TypeName = "varchar(25)", Order = 2)]
	public string Name { get; set; }

	/*
	public EliminationLevel Level { get; set; } = EliminationLevel.Single;

	public DrawType Type { get; set; }

	public TournamentState State { get; set; }
	*/

	public int MinPlayers { get; set; } = 2;

	public int MaxPlayers { get; set; }
}
