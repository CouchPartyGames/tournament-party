using MediatR;
using Domain.Entities;

namespace Application.Tournaments;

public sealed class CreateTournamentHandler : IRequestHandler<CreateTournamentCommand, Tournament>
{

    public async Task<Tournament> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
    {
        var response = new Tournament();
        return response;
    }

}

