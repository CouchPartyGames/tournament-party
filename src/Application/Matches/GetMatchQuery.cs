using Domain.Entities;
using MediatR;

namespace Application.Matches;

public record GetMatchQuery(string name) : IRequest<Match>;

