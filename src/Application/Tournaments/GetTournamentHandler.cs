using MediatR;
using Domain.Entities;


namespace Application.Tournaments;

public sealed class GetTournamentHandler : IRequestHandler<GetTournamentQuery, Tournament>
{
    public async Task<Tournament> Handle(GetTournamentQuery request, CancellationToken cancellationToken)
    {
        var response = new Tournament();
        // Some logic 
        return response;
    }
}
