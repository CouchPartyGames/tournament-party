using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IMatchRepository {
    Match GetByIdAsync(int id);

}

