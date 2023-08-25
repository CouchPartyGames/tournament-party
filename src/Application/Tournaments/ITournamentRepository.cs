using Domain.Tournament;

namespace Application.Interfaces.Repositories;

public interface ITournamentRepository
{
    Task<Tournament> GetByIdAsync(int id);

    Task<Tournament> Add(Tournament tournament);

    Task DeleteByIdAsync(int id);

    Task<Tournament> UpdateByIdAsync(Tournament tournament);

}
