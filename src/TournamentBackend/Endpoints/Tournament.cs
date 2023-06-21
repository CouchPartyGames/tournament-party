using CouchParty.TournamentBackend.Data;
using System.ComponentModel.DataAnnotations;
using TournamentModel = CouchParty.TournamentBackend.Models.Tournament;

namespace CouchParty.TournamentBackend.Endpoints;

public static class Tournament {

	public static void AddTournamentEndpoints(this IEndpointRouteBuilder app) {

		var group = app.MapGroup("/v1/tournaments/");

		group.MapGet("{id}", GetTournament)
			.WithName("GetTournament");
     		//.AllowAnonymous();

		group.MapPut("{id}", UpdateTournament)
			.WithName("UpdateTournament")
  			.AddEndpointFilter<ValidatorFilter<UpdateTournamentRequest>>();
        	//.RequireAuthorization("Owner")
        	//.RequireAuthorization("Admin");

		group.MapPost("", CreateTournament)
			.WithName("CreateTournament")
  			.AddEndpointFilter<ValidatorFilter<CreateTournamentRequest>>();
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

            // Create Tournament from a Template
        group.MapPut("templates/{id}", CreateTournamentFromTemplate)
			.WithName("CreateTournamentFromTemplate");

		group.MapDelete("{id}", DeleteTournament)
			.WithName("DeleteTournament");
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		group.MapGet("{id}/start", Start)
			.WithName("StartTournament");
  			//.RequireAuthorization("Owner")
			//.RequireAuthorization("Admin");

		group.MapPost("{id}/complete", Complete)
			.WithName("CompleteTournament");

	}


    /// <summary>
    /// Returns a specific Tournament.
    /// </summary>
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
    public static Results<Created, BadRequest<List<string>>> CreateTournament(CreateTournamentRequest request, 
		TournamentContext db, 
		IValidator<CreateTournamentRequest> validator) {

		/*
        FluentValidation.Results.ValidationResult results = validator.Validate(request);
		if (!results.IsValid) {
            return TypedResults.BadRequest(FluentValidationErrors.ResultToStrings(results.Errors));
        }*/

        var tournament = new TournamentModel { Name = request.Name };
        db.Add(tournament);
        db.SaveChanges();

		return TypedResults.Created($"/v1/tournaments/{tournament.Id}");
	}

	
    /// <summary>
    /// Creates a Tournament from a Preset Template
    /// </summary>
    public static Results<Created, NotFound> CreateTournamentFromTemplate(int id, TournamentContext db) {
        var template = db.Template.Find(id);
        if (template is null) {
            return TypedResults.NotFound();
        }

        var tournament = new TournamentModel { Name = template.Name };
        db.Add(tournament);
        db.SaveChanges();

		return TypedResults.Created($"/v1/tournaments/{tournament.Id}");
	} 

    /// <summary>
    /// Updates a specific Tournament.
    /// </summary>
    public static Results<Ok<ApiSuccess>, BadRequest<List<ValidationFailure>>, NotFound> UpdateTournament(int id, 
		CreateTournamentRequest request, 
		TournamentContext db, 
		IValidator<CreateTournamentRequest> validator) {

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
    public static Results<NoContent, NotFound> DeleteTournament(int id, TournamentContext db) { 
        var tournament = db.Tournament.Find(id);

        if (tournament is null) {
			return TypedResults.NotFound();
		}

        
        db.Remove(tournament);
        db.SaveChanges();

        return TypedResults.NoContent();
	}


    /// <summary>
    /// Finalize and Create tournament matches
    /// </summary>
	public static Results<NoContent, NotFound> Finalize(int id, TournamentContext db) {
        var tournament = db.Tournament.Find(id);
        if (tournament is null) {
			return TypedResults.NotFound();
		}

		// Create Matches	
		return TypedResults.NoContent();
	}

    /// <summary>
    /// Start the tournament
    /// </summary>
	public static Results<NoContent, NotFound> Start(int id, TournamentContext db, IConnectionMultiplexer redis) {
        var tournament = db.Tournament.Find(id);
        if (tournament is null) {
			return TypedResults.NotFound();
		}

		tournament.State = TournamentModel.TournamentState.Start;

		// Add Players to Database
		// Remove Players from Redis List
		//var db = redis.GetDatabase();

		return TypedResults.NoContent();
	}


    /// <summary>
    /// Set the Tournament to completed.
    /// </summary>
	public static Results<NoContent, NotFound> Complete(int id, TournamentContext db) {
        var tournament = db.Tournament.Find(id);
        if (tournament is null) {
			return TypedResults.NotFound();
		}

		tournament.State = TournamentModel.TournamentState.Completed;
        db.SaveChanges();

		return TypedResults.NoContent();
	}


}
