using CouchParty.TournamentBackend.Data;
using System.ComponentModel.DataAnnotations;
using TournamentModel = CouchParty.TournamentBackend.Models.Tournament;

namespace CouchParty.TournamentBackend.Endpoints;

public static class Tournament {

	public static void TournamentEndpoints(this WebApplication app) {


		app.MapGet("/v1/tournaments/{id}", GetTournament)
			.WithName("GetTournament");
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

            // Create Tournament from a Template
        app.MapPut("/v1/tournaments/templates/{id}", CreateTournamentFromTemplate)
			.WithName("CreateTournamentFromTemplate");

		app.MapDelete("/v1/tournaments/{id}", DeleteTournament)
			.WithName("DeleteTournament");
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		app.MapGet("/v1/tournaments/{id}/start", Start)
			.WithName("StartTournament");
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		app.MapPost("/v1/tournaments/{id}/complete", Complete)
			.WithName("CompleteTournament");

		app.MapPost("/v1/tournaments/{id}/enter", Enter)
			.WithName("EnterTournament");

		app.MapPost("/v1/tournaments/{id}/exit", Leave)
			.WithName("LeaveTournament");
	}


    /// <summary>
    /// Returns a specific Tournament.
    /// </summary>
    /// <param name="id"></param>
    public static Results<Ok<ApiSuccess>, NotFound> GetTournament(int id, TournamentContext db) { 
		var results = db.Tournament.Where(x => x.Id == id).FirstOrDefault();
		if (results is null) {
        	return TypedResults.NotFound();
		}

		ApiSuccess success = new() {
			Results = results
		};
		return TypedResults.Ok(success);
    }

    /// <summary>
    /// Creates a Tournament.
    /// </summary>
    public static Results<Created<ApiSuccess>, BadRequest<List<ValidationFailure>>> CreateTournament(CreateTournamentRequest request, TournamentContext db, IValidator<CreateTournamentRequest> validator) {

        FluentValidation.Results.ValidationResult results = validator.Validate(request);
		if (!results.IsValid) {
            return TypedResults.BadRequest(results.Errors);
        }

        var tournament = new TournamentModel { Name = request.Name };
        db.Add(tournament);
        db.SaveChanges();

        ApiSuccess success = new() {
			Results = tournament
		};
		return TypedResults.Created("/v1/tournaments/", success);
	}

	
    /// <summary>
    /// Creates a Tournament from a Preset Template
    /// </summary>
    public static Results<Created, NotFound> CreateTournamentFromTemplate(int templateId, TournamentContext db) {
		return TypedResults.Created("/v1/tournaments/");
	} 

    /// <summary>
    /// Updates a specific Tournament.
    /// </summary>
    /// <param name="id"></param>
    public static Results<Ok<ApiSuccess>, BadRequest<List<ValidationFailure>>, NotFound> UpdateTournament(int id, CreateTournamentRequest request, TournamentContext db, IValidator<CreateTournamentRequest> validator) {

        FluentValidation.Results.ValidationResult results = validator.Validate(request);
        if (!results.IsValid) {
            return TypedResults.BadRequest(results.Errors);

        }

        var tournament = db.Tournament.Find(id);
        if (tournament is null) {
            return TypedResults.NotFound();
        }


		db.SaveChanges();
        ApiSuccess success = new() {
			Results = "hello tournaments"
		};
		return TypedResults.Ok(success);
	}

    /// <summary>
    /// Deletes a specific Tournament.
    /// </summary>
    /// <param name="id"></param>
    public static Results<NoContent, NotFound> DeleteTournament(int id, TournamentContext db) { 
        var tournament = db.Tournament.Find(id);

        if (tournament is null) {
			return TypedResults.NotFound();
		}

        
        db.Remove(tournament);
        db.SaveChanges();

        return TypedResults.NoContent();
	}

	public static Results<NoContent, NotFound> Finalize(int id) {
		// Get Tournament
		// Create Matches	
		return TypedResults.NoContent();
	}

	// Tournament has started
	public static Results<Ok<ApiSuccess>, NotFound> Start(int id, IConnectionMultiplexer redis) {
		// Start Tournament
		// Add Players to Database
		// Remove Players from Redis List
		//var db = redis.GetDatabase();
		ApiSuccess success = new() {
			Results = "hello tournaments"
		};
		return TypedResults.Ok(success);
	}

	// Tournament is finished/completed
	public static Results<Ok<ApiSuccess>, NotFound> Complete(int id) {
		ApiSuccess success = new() {
			Results = "hello tournaments"
		};
		return TypedResults.Ok(success);
	}

	// Player enters the tournament
	public static Results<NoContent, NotFound> Enter(int id, IConnectionMultiplexer redis) {
		// Make sure tournament exists
		// Make sure tournament allowing entry
		// Make sure tournament not started
		// Add player to redis (list)
		//var db = redis.GetDatabase();

		return TypedResults.NoContent();
	}

	// Player no longer wishes to compete in the tournament
	public static Results<NoContent, NotFound> Leave(int id, IConnectionMultiplexer redis) {
		// Make sure tournament exists
		// Remove player from Redis (list)
		//var db = redis.GetDatabase();

		return TypedResults.NoContent();
	}
}
