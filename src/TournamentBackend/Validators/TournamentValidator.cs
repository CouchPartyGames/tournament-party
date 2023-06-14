namespace CouchParty.TournamentBackend.Validators;

public sealed class TournamentValidator : AbstractValidator<CreateTournamentRequest> {

	public TournamentValidator() {
		RuleFor(x => x.Name)
			.NotEmpty()
            .MinimumLength(5)
			.WithMessage("Invalid name of tournament");

		/*
		RuleFor(x => x.Level)
			.IsInEnum();

		RuleFor(x => x.Type)
			.IsInEnum();
		*/
	}

}
