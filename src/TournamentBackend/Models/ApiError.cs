namespace CouchParty.TournamentBackend.Models;

public sealed class ApiError {
	public bool IsSuccess { get; } = false;
	public List<string> ErrorMessages { get; set; }
}
