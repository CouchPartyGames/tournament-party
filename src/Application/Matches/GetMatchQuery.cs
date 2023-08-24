using Domain.Match;
using MediatR;

namespace Application.Matches;

public record GetMatchQuery(string name) : IRequest<Match>;

