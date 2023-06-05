namespace CouchParty.TournamentBackend.Models;


public class ApiSuccess {
	public bool IsSuccess { get; } = true;

	public Object Results { get; set; } 
}
