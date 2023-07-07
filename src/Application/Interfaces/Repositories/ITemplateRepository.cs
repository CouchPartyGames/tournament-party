using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ITemplateRepository
{

    Task<Template> GetByIdAsync(Guid id);

    Task<Template> Add(Template template);

    Task<Template> Update(Template template);

    Task<Template> Delete(Guid id);

}
