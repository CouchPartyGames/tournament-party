using MediatR;


namespace Application.Handlers;

public sealed class CreateTournamentHandler : IRequestHandler<CreateTouranmentCommand> {
    public CreateTournamentHandler() { }

    /*
    public async Task<bool> Handle(CreateTournamentCommnd request,
        CancellationToken cancellationToken) {
        return await _fakeDataStore.GetAllProducts();
    }*/

}

