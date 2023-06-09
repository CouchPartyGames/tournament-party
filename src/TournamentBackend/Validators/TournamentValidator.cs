namespace CouchParty.TournamentBackend.Validators;


using TournamentModel = CouchParty.TournamentBackend.Models.Tournament;

public sealed class TournamentValidator : AbstractValidator<CreateTournamentRequest> {

	public TournamentValidator() {
		RuleFor(x => x.Name)
			.NotEmpty()
            .MinimumLength(5)
			.WithMessage("Invalid name of tournament");

		
		//RuleFor(x => x.Level).IsInEnum();
		//RuleFor(x => x.Level)
		//	.IsEnumName(typeof(TournamentModel.EliminationLevel), caseSensitive: false);

		/*
		RuleFor(x => x.Type)
			.IsInEnum();
		*/
	}

}
