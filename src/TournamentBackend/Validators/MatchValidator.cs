namespace TournamentTime.Validators;

public sealed class MatchValidator : AbstractValidator<MatchDTO> {

	public MatchValidator() {
		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Invalid name of tournament");
	}
}
