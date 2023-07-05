using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ITemplateRepository
{

    Template GetByIdAsync(Guid id);
}
