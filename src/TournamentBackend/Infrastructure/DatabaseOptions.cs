namespace Options;

public sealed class DatabaseOptions {

	public string Type { get; set; }
	public string ConnectionString { get; set; }
}


public sealed class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions> {

	private const string SECTION_NAME = "Database";

	private readonly IConfiguration _configuration;

    public DatabaseOptionsSetup(IConfiguration configuration) {
        _configuration = configuration;
    }

    public void Configure(DatabaseOptions options) {
        _configuration
            .GetSection(SECTION_NAME)
            .Bind(options)
			.Validate(settings => {
				//if (settings.Type) {
				// return false;
				//}

				return true;
			})
			.ValidateOnStartup();
    }
}
