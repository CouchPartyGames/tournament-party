using Domain.Tournament;
using MediatR;

namespace Application.Tournaments;

public record CreateTournamentCommand(string name) : IRequest<Tournament>;
