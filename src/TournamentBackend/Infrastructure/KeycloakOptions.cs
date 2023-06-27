namespace Options;

public sealed class KeycloakOptions {

	public string Url { get; set; }
	public string Realm { get ; set ; }
	public string Resource { get ; set ; }

}

public sealed class KeycloakOptionsSetup : IConfigureOptions<KeycloakOptions> {

	private const string SECTION_NAME = "Keycloak";

	private readonly IConfiguration _configuration;

    public KeycloakOptionsSetup(IConfiguration configuration) {
        _configuration = configuration;
    }

    public void Configure(KeycloakOptions options) {
		/*
        _configuration
            .GetSection(SECTION_NAME)
            .Bind(options)
			.Validate(settings => {
				//if (settings.Url) {
				// return false;
				//}

				return true;
			});
			//.ValidateOnStart();
		*/
    }
}

