using Domain.Entities;
using MediatR;

namespace Application.Tournaments;

public record GetTournamentQuery(Guid id) : IRequest<Tournament>;
