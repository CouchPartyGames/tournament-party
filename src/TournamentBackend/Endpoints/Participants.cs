namespace CouchParty.TournamentBackend.Endpoints;

public static class Participants {


	public static void ParticipantsEndpoints(this WebApplication app) {

		app.MapPost("/v1/participants/tournaments/{id}", JoinTournament)
			.WithName("Join");

		app.MapDelete("/v1/participants/tournaments/{id}", LeaveTournament)
			.WithName("Leave");

	}


    /// <summary>
    /// Join a tournament
    /// </summary>
	public static Results<NoContent, NotFound> JoinTournament(int id, TournamentContext db) {
        var template = db.Template.Find(id);
        if (template is null) {
            return TypedResults.NotFound();
        }

		return TypedResults.NoContent();
	}

    /// <summary>
    /// Leave a tournament
    /// </summary>
	public static Results<NoContent, NotFound> LeaveTournament(int id, TournamentContext db) {
        var template = db.Template.Find(id);
        if (template is null) {
            return TypedResults.NotFound();
        }

		return TypedResults.NoContent();
	}
}
