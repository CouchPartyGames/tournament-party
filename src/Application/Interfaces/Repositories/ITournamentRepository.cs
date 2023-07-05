using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ITournamentRepository
{
    Tournament GetByIdAsync(int id);
}
