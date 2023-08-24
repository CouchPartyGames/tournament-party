using Domain.Abstractions;

namespace Domain.Tournament;

public static class TournamentErrors {

    public static Error RegistrationIsClosed  { get; } = new Error("TournamentErrors.RegistrationClosed", "Tournament's registration is closed");

}