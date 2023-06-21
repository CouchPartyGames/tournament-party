namespace CouchParty.TournamentBackend.Endpoints;

using MatchModel = CouchParty.TournamentBackend.Models.Match;

public static class Match {

	public static void AddMatchEndpoints(this IEndpointRouteBuilder app) {

		var group = app.MapGroup("/v1/matches/");

		group.MapGet("{id}", GetMatch)
			.WithName("GetMatch");
     		//.AllowAnonymous();

		group.MapPut("{id}", UpdateMatch)
			.WithName("UpdateMatch");
  			//.AddEndpointFilter<ValidatorFilter<UpdateMatchRequest>>();
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		group.MapDelete("{id}", DeleteMatch)
			.WithName("DeleteMatch");
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");
	}


    /// <summary>
    /// Get a specific Match
    /// </summary>
	public static Results<Ok<MatchModel>, NotFound> GetMatch(int id, TournamentContext db) {
        var match = db.Match.Find(id);
        if (match is null) {
            return TypedResults.NotFound();
		}

		return TypedResults.Ok(match);
	}

    /// <summary>
    /// Update a specific Match
    /// </summary>
	public static Results<Ok<MatchModel>, NotFound> UpdateMatch(int id, UpdateMatchRequest request, TournamentContext db) {
        var match = db.Match.Find(id);
		if (match is null) {
			return TypedResults.NotFound();
		}

		//match.
		db.SaveChanges();

		return TypedResults.Ok(match);
	}


    /// <summary>
    /// Deletes a specific Match
    /// </summary>
	public static Results<NoContent, NotFound> DeleteMatch(int id, TournamentContext db) {
        var match = db.Match.Find(id);
		if (match is null) {
			return TypedResults.NotFound();
		}

        db.Remove(match);
        int changes = db.SaveChanges();
		if (changes > 0) {
			return TypedResults.NoContent();
		}

			// Gone - 410 (already deleted)
		//return TypedResults.ProblemHttpResult(410);
		return TypedResults.NotFound();
	}
}
