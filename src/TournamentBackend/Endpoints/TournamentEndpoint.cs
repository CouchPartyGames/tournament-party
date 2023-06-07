namespace CouchParty.TournamentBackend.Endpoints;

public static class TournamentEndpoint {

	public static void TournamentEndpoints(this WebApplication app) {

		//app.MapGet("/v{version:apiVersion}/tournaments/{id}", GetTournament)
   			//.WithApiVersionSet(versionSet)
			//.HasApiVersions(new [] { new ApiVersion(1), new ApiVersion(2) });

		app.MapGet("/v1/tournaments", GetTournaments)
			.WithName("GetTournaments")
			.Produces<ApiError>(400)
			.Produces<ApiError>(404)
			.Produces<ApiSuccess>(200);
     		//.AllowAnonymous();

		app.MapGet("/v1/tournaments/{id}", GetTournament)
			.WithName("GetTournament")
			.Produces<ApiError>(400)
			.Produces<ApiError>(404)
			.Produces<ApiSuccess>(200);
     		//.AllowAnonymous();

		app.MapPut("/v1/tournaments/{id}", UpdateTournament)
			.WithName("UpdateTournament")
			.Accepts<CreateTournamentRequest>("application/json")
			.Produces<ApiError>(400)
			.Produces<ApiError>(404)
			.Produces<ApiError>(StatusCodes.Status422UnprocessableEntity)
			.Produces<ApiSuccess>(200)
  			.AddEndpointFilter<ValidatorFilter<CreateTournamentRequest>>();
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		app.MapPost("/v1/tournaments", CreateTournament)
			.WithName("CreateTournament")
			.Accepts<CreateTournamentRequest>("application/json")
			.Produces<ApiError>(400)
			.Produces<ApiError>(StatusCodes.Status422UnprocessableEntity)
			.Produces<ApiSuccess>(201)
  			.AddEndpointFilter<ValidatorFilter<CreateTournamentRequest>>();
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		app.MapDelete("/v1/tournaments/{id}", DeleteTournament)
			.WithName("DeleteTournament")
			.Produces<ApiError>(400)
			.Produces<ApiError>(404)
			.Produces(204);
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		app.MapGet("/v1/tournaments/{id}/start", Start)
			.WithName("StartTournament")
			.Produces<ApiError>(400)
			.Produces<ApiError>(404)
			.Produces<ApiSuccess>(200);
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		app.MapPost("/v1/tournaments/{id}/complete", Complete)
			.WithName("CompleteTournament")
			.Produces<ApiError>(400)
			.Produces<ApiError>(404)
			.Produces<ApiSuccess>(200);
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		app.MapPost("/v1/tournaments/{id}/enter", Enter)
			.WithName("EnterTournament")
			.Produces(404)
			.Produces(204);

		app.MapPost("/v1/tournaments/{id}/exit", Exit)
			.WithName("ExitTournament")
			.Produces(400)
			.Produces(204);
	}


	public static Results<Ok<ApiSuccess>, BadRequest<ApiError>, NotFound> GetTournaments() {
		if (false) {
			ApiError err = new() {
				ErrorMessages = new List<string>() { "Bad stuff" }
			};
			return TypedResults.BadRequest(err);
		}

		using (var context = new TournamentContext()) {
			
			var tournys = context.Tournament.ToList();
			ApiSuccess success = new() {
				Results = tournys
			};
			return TypedResults.Ok(success);
		}
		
	}

	public static Results<Ok<ApiSuccess>, NotFound> GetTournament(string id) {
		//return TypedResults.BadRequest();
		//return TypedResults.NotFound();
		using (var db = new TournamentContext()) {
			var results = db.Tournament.Where(x => x.Id == id).First();
			
			
			ApiSuccess success = new() {
				Results = results
			};
			return TypedResults.Ok(success);
		}
	}


	public static Results<Created<ApiSuccess>, BadRequest, NotFound> CreateTournament(CreateTournamentRequest request /*, */
		/*IValidator<CreateTournamentRequest> validator*/) {
/*
		ValidationResult results = validator.Validate(request);
		if (!results.IsValid) {
			//return Results.ValidationProblem(results.Errors);
			return Results.BadRequest(results.Errors);
		}
*/

/*
		using (var context = new TournamentContext()) {
			try {
				context.Add(new Tournament {
					Id = "test",
					Name = "First Tournament"
				});
				context.SaveChanges();
			} catch(DbUpdateException e) {
				return TypedResults.BadRequest("failed");
			}
		}
*/

		ApiSuccess success = new() {
			Results = "hello tournaments"
		};
		return TypedResults.Created("/v1/tournaments/1", success);
	}

	public static Results<Ok<ApiSuccess>, NotFound> UpdateTournament(CreateTournamentRequest request) {
		//return Results.BadRequest();
		//return Results.NotFound();

		ApiSuccess success = new() {
			Results = "hello tournaments"
		};
		return TypedResults.Ok(success);
	}

	public static Results<NoContent, NotFound> DeleteTournament(string id) {
		//return Results.BadRequest();
		if (false) {
			return TypedResults.NotFound();
		}

		return TypedResults.NoContent();
	}

	public static Results<NoContent, NotFound> Finalize(string id) {
		// Get Tournament
		// Create Matches	
		return TypedResults.NoContent();
	}

	// Tournament has started
	public static Results<Ok<ApiSuccess>, NotFound> Start(IConnectionMultiplexer redis, string id) {
		// Start Tournament
		// Add Players to Database
		// Remove Players from Redis List
		var db = redis.GetDatabase();
		ApiSuccess success = new() {
			Results = "hello tournaments"
		};
		return TypedResults.Ok(success);
	}

	// Tournament is finished/completed
	public static Results<Ok<ApiSuccess>, NotFound> Complete(string id) {
		ApiSuccess success = new() {
			Results = "hello tournaments"
		};
		return TypedResults.Ok(success);
	}

	// Player enters the tournament
	public static Results<NoContent, NotFound> Enter(IConnectionMultiplexer redis, string id) {
		// Make sure tournament exists
		// Make sure tournament allowing entry
		// Make sure tournament not started
		// Add player to redis (list)
		var db = redis.GetDatabase();

		return TypedResults.NoContent();
	}

	// Player no longer wishes to compete in the tournament
	public static Results<NoContent, NotFound> Exit(IConnectionMultiplexer redis, string id) {
		// Make sure tournament exists
		// Remove player from Redis (list)
		var db = redis.GetDatabase();

		return TypedResults.NoContent();
	}
}
