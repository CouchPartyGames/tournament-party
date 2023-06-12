namespace CouchParty.TournamentBackend.Endpoints;


public static class MatchEndpoint {

	public static void MatchEndpoints(this WebApplication app) {

		app.MapGet("/v1/matches/{id}", GetMatch)
			.WithName("GetMatch")
			.Produces<ApiError>(400)
			.Produces<ApiError>(404)
			.Produces<ApiSuccess>(200);
     		//.AllowAnonymous();

		app.MapPut("/v1/matches/{id}", UpdateMatch)
			.WithName("UpdateMatch")
			.Accepts<MatchDTO>("application/json")
			.Produces<ApiError>(400)
			.Produces<ApiError>(404)
			.Produces<ApiError>(StatusCodes.Status422UnprocessableEntity)
			.Produces<ApiSuccess>(200);
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
	public static Results<Ok<ApiSuccess>, NotFound> GetMatch(string tournamentId, string matchId) {
		if (false) {
			return TypedResults.NotFound();
		}

		/*
		var match = context.Matches
			.Where(p => p.Id == id);

		if (!match) {
			return Results.NotFound();
		}
		*/

		//Match match 
		ApiSuccess match = new() { Results = $"match {matchId}" };

		return TypedResults.Ok(match);
	}

    /// <summary>
    /// Update a specific Match
    /// </summary>
    /// <param name="id"></param>
	public static Results<Ok<ApiSuccess>, NotFound> UpdateMatch(string matchId, TournamentContext db) {
        var match = db.Match.Find(matchId);
		if (match is null) {
			return TypedResults.NotFound();
		}

		ApiSuccess success = new() { Results = "match" };
		return TypedResults.Ok(success);
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
        db.SaveChanges();

		return TypedResults.NoContent();
	}
}
