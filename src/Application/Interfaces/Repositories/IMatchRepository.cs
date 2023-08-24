using Domain.Match;

namespace Application.Interfaces.Repositories;

public interface IMatchRepository {
    Task<Match> GetByIdAsync(int id);

    Task<Match> Add(Match match);

    Task DeleteByIdAsync(int id);  

    Task<Match> UpdateByIdAsync(Match match);

}

