using MediatR;
using Domain.Tournament;
using Application.Interfaces.Repositories;

namespace Application.Tournaments;

public sealed class GetTournamentHandler : IRequestHandler<GetTournamentQuery, Tournament>
{
    public GetTournamentHandler(ITournamentRepository repo) { }

    public async Task<Tournament> Handle(GetTournamentQuery request, CancellationToken cancellationToken)
    {
        var response = new Tournament();
        // Some logic 
        return response;
    }
}
