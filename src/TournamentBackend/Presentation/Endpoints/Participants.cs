namespace CouchParty.TournamentBackend.Endpoints;

public static class Participants {


	public static void AddParticipantsEndpoints(this IEndpointRouteBuilder app) {
		var group = app.MapGroup("/v1/participants/");

		group.MapPost("tournaments/{id}", JoinTournament)
			.WithName("Join");

		group.MapDelete("/tournaments/{id}", LeaveTournament)
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
