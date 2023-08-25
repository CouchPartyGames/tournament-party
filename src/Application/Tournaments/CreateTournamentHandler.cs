using MediatR;
using Domain.Tournament;
using Domain.Abstractions;
using Application.Interfaces.Repositories;

namespace Application.Tournaments;

internal sealed class CreateTournamentHandler : IRequestHandler<CreateTournamentCommand, Tournament> {

    private ITournamentRepository _tournamentRepository;

    public CreateTournamentHandler(ITournamentRepository tournamentRepository) {
        _tournamentRepository = tournamentRepository;
    }

    public async Task<Result<Tournament>> Handle(CreateTournamentCommand request, CancellationToken cancellationToken) {

        var tournament = new Tournament();
        //var tournament = await _tournamentRepository(tournament);
        return Tournament.Id;
    }

}

