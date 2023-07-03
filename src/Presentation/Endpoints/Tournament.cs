namespace Presentation.Endpoints;

using Microsoft.AspNetCore.Routing;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

public static class Tournament
{

    public static void AddTournamentEndpoints(this IEndpointRouteBuilder app)
    {
        //IMediator mediator;
        var group = app.MapGroup("/v1/tournaments/");

        group.MapGet("{id}", GetTournament)
            .WithName("GetTournament");
        //.AllowAnonymous();


    }


    /// <summary>
    /// Returns a specific Tournament.
    /// </summary>
    public static async Results<Ok<Tournament>, NotFound> GetTournament(int id, IMediator mediator)
    {
        var result = await mediator.Send(new GetTournamentQuery());
        return TypedResults.Ok(results);
    }

}