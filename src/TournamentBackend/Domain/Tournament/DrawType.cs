namespace Domain.Tournament.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DrawType {
	Seeded = 0,
	Blind
}
