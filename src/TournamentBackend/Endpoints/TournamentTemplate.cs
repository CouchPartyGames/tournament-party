namespace CouchParty.TournamentBackend.Endpoints;

public static class TournamentTemplate {

    public static void TournamentTemplates(this WebApplication app) {

        app.MapGet("/v1/template/{id}", GetTemplate)
			.WithName("GetTemplate");
        /*
		app.MapPost("/v1/template/", CreateTemplate);
        app.MapDelete("/v1/template", DeleteTemplate);
        app.MapPut("/v1/template", UpdateTemplate);
		*/
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
}

