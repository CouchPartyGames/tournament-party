using Domain.Tournament.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EliminationLevel {
	Single = 0,
	Double,
	Triple
}
