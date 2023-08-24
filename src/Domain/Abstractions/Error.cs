namespace Domain.Abstractions;

public sealed record Error(string Code, string Message) {

    public static Error NullValue = new Error("Error.Null", "Null value was provided");

    public static Error None = new Error(string.Empty, string.Empty);

}