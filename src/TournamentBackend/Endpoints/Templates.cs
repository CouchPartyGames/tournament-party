namespace CouchParty.TournamentBackend.Endpoints;

using TemplateModel = CouchParty.TournamentBackend.Models.Template;

public static class Templates {

    public static void TemplateEndpoints(this WebApplication app) {

        app.MapGet("/v1/templates/{id}", GetTemplate)
			.WithName("GetTemplate");

		app.MapPost("/v1/templates", CreateTemplate)
			.WithName("CreateTemplate");

        app.MapPut("/v1/templates", UpdateTemplate)
			.WithName("UpdateTemplate");

        app.MapDelete("/v1/templates", DeleteTemplate)
			.WithName("DeleteTemplate");

    } 

    /// <summary>
    /// Get a specific Template
    /// </summary>
	public static Results<Ok<TemplateModel>, NotFound> GetTemplate(int id, TournamentContext db) {
        var template = db.Template.Find(id);
        if (template is null) {
            return TypedResults.NotFound();
        }

		return TypedResults.Ok(template);
	}

    /// <summary>
    /// Create a new Template
    /// </summary>
	public static Results<Created, BadRequest<List<ValidationFailure>>> CreateTemplate(CreateTemplateRequest request, 
		TournamentContext db/*,
		IValidator<CreateTemplateRequest> validator*/) {

        /*
		FluentValidation.Results.ValidationResult results = validator.Validate(request);
		if (!results.IsValid) {
            return TypedResults.BadRequest(results.Errors);
        }
		*/

        var template = new TemplateModel { Name = request.Name };
        db.Add(template);
		db.SaveChanges();

		return TypedResults.Created($"/v1/templates/{template.Id}");
	}

    /// <summary>
    /// Update a specific Template
    /// </summary>
	public static Results<Ok, BadRequest, NotFound> UpdateTemplate(int id, UpdateTemplateRequest request, 
		TournamentContext db/*,
		IValidator<UpdateTemplateRequest> validator*/) {

		/*
        FluentValidation.Results.ValidationResult results = validator.Validate(request);
		if (!results.IsValid) {
            return TypedResults.BadRequest(results.Errors);
        }
		*/

        var template = db.Template.Find(id);
        if (template is null) {
            return TypedResults.NotFound();
        }

		template.Name = request.Name;
		db.SaveChanges();

		return TypedResults.Ok();
	}

    /// <summary>
    /// Delete  a specific Template
    /// </summary>
	public static Results<NoContent, BadRequest, NotFound> DeleteTemplate(int id, TournamentContext db) {

        var template = db.Tournament.Find(id);
        if (template is null) {
			return TypedResults.NotFound();
		}

        db.Remove(template);
        db.SaveChanges();

		return TypedResults.NoContent();
	}
}

