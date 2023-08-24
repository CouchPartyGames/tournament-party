namespace Domain.Match;

public sealed class Score {
    public string Text { get; set; }
    public Score(string score) => Text = score;
}