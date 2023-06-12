namespace CouchParty.TournamentBackend.Endpoints;

using MatchModel = CouchParty.TournamentBackend.Models.Match;

public static class Match {

	public static void MatchEndpoints(this WebApplication app) {

		app.MapGet("/v1/matches/{id}", GetMatch)
			.WithName("GetMatch");
     		//.AllowAnonymous();

		app.MapPut("/v1/matches/{id}", UpdateMatch)
			.WithName("UpdateMatch");
  			//.AddEndpointFilter<ValidatorFilter<MatchDTO>>();
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		app.MapDelete("/v1/matches/{id}", DeleteMatch)
			.WithName("DeleteMatch");
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");
	}


    /// <summary>
    /// Get a specific Match
    /// </summary>
    /// <param name="id"></param>
	public static Results<Ok<MatchModel>, NotFound> GetMatch(string matchId, TournamentContext db) {
        var match = db.Match.Find(matchId);
        if (match is null) {
            return TypedResults.NotFound();
		}

		return TypedResults.Ok(match);
	}

    /// <summary>
    /// Update a specific Match
    /// </summary>
    /// <param name="id"></param>
	public static Results<Ok<MatchModel>, NotFound> UpdateMatch(string matchId, TournamentContext db) {
        var match = db.Match.Find(matchId);
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
    /// <param name="id"></param>
	public static Results<NoContent, NotFound> DeleteMatch(string matchId, TournamentContext db) {
        var match = db.Match.Find(matchId);
		if (match is null) {
			return TypedResults.NotFound();
		}

        db.Remove(match);
        int changes = db.SaveChanges();
		if (changes > 0) {
			return TypedResults.NoContent();
		}

		return TypedResults.NotFound();
	}
}
