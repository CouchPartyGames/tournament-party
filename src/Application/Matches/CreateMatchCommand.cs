using Domain.Entities;
using MediatR;

namespace Application.Matches;

public record  CreateMatchCommand(string Name) : IRequest<Match>;
