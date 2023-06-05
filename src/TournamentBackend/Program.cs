var builder = WebApplication.CreateBuilder(args);

/* Serilog
builder.Logging.ClearProviders();
var logging = new LoggingConfiguration()
	.WriteTo.Console().CreateLogger();
builder.Logging.AddSerilog(logging);
*/

builder.Logging.AddJsonConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
/*	Sample Health Checks
builder.Services.AddHealthChecks()
	.AddCheck<SampleHealthCheck>("Sample")
	.RequireHost("www.contoso.com:5001");
*/

/*	Authentication/Authorization
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
	.AddSteam();

builder.Services.AddAuthorization();

*/


/*
builder.Services.AddApiVersioning(options => {
	options.ReportApiVersions = true;
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new ApiVersion(1);
	options.ApiVersionReader = new QueryStringApiVersionReader("version");
});
*/

builder.Services.AddDbContext<TournamentContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


var app = builder.Build();
/*
var versionSet = app.NewApiVersionSet()
	.HasApiVersion(new ApiVersion(1))
	.HasApiVersion(new ApiVersion(2))
	.ReportApiVersions()
	.Build();
*/

//app.UseAuthentication();
//app.UseAuthorization();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapHealthChecks("/healthz");
app.MatchEndpoints();
app.TournamentEndpoints();

app.Run();
