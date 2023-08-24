namespace Domain.Match;

public sealed class Attachment {
    public Ulid Id { get; init; }

    public string Url { get; init; }

    public Attachment(Ulid ulid, string url) => (Id, Url) = (ulid, url);

}