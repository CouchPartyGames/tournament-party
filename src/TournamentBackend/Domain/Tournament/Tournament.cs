namespace Domain.Tournament.Entities;

using Domain.Tournament.Enums;

public sealed class Tournament {
	
	[Column(Order = 1)]
	public int Id { get; private set; }
	//public CompactGuid Id { get; private set; }

	[Required]
	[Column(TypeName = "varchar(25)", Order = 2)]
	public string Name { get; private set; }

	public EliminationLevel Level { get; private set; } = EliminationLevel.Single;

	public DrawType Type { get; private set; }

	public TournamentState State { get; private set; }

	public DateOnly Date { get; private set; }

	public TimeOnly Time { get; private set; }

	public int MinPlayers { get; private set; } = 2;

	public int MaxPlayers { get; private set; }
}
