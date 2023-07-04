using Domain.Entities;
using MediatR;

namespace Application.Templates;

public  record CreateTemplateCommand(string name) : IRequest<Template>;
