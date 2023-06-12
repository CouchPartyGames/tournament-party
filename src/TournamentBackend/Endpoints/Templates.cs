namespace CouchParty.TournamentBackend.Endpoints;

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
    /// <param name="id"></param>
	public static Results<Ok<ApiSuccess>, NotFound> GetTemplate(string templateId) {
		if (false) {
			return TypedResults.NotFound();
		}

		// Match match 
		ApiSuccess match = new() { Results = $"template" };

		return TypedResults.Ok(match);
	}

    /// <summary>
    /// Create Template
    /// </summary>
    /// <param name="id"></param>
	public static Results<Created, BadRequest> CreateTemplate() {
		return TypedResults.Created("/v1/templates/");
	}

    /// <summary>
    /// Update a specific Template
    /// </summary>
    /// <param name="id"></param>
	public static Results<Ok, BadRequest> UpdateTemplate() {
		return TypedResults.Ok();
	}

    /// <summary>
    /// Delete  a specific Template
    /// </summary>
    /// <param name="id"></param>
	public static Results<NoContent, BadRequest> DeleteTemplate() {
		return TypedResults.NoContent();
	}
}

