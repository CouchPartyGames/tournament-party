using System.Reflection;
using Serilog;
using Serilog.Formatting.Compact;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new RenderedCompactJsonFormatter())
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);


var multiplexer = ConnectionMultiplexer.Connect("localhost");

builder.Host.UseSerilog(); 
builder.Logging.AddJsonConsole();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => {
	options.SerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
	options.SwaggerDoc("v1", new OpenApiInfo { 
		Version = "v1",
		Title = "Tournament Backend API", 
		Description = "Backend API for a Realtime Tournament Management System",
		TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact {
            Name = "Contact",
            Url = new Uri("https://github.com/CouchPartyGames/tournament-party/issues/new")
        },
        License = new OpenApiLicense {
            Name = "License",
            Url = new Uri("https://github.com/CouchPartyGames/tournament-party/blob/main/LICENSE")
        }
	});

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);


builder.Services.AddHealthChecks()
	.AddRedis(builder.Configuration["Redis:ConnectionString"])
    .AddNpgSql(builder.Configuration["ConnectionString"]);


/*	Authentication/Authorization
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAuthorization();
*/


builder.Services.AddDbContext<TournamentContext>(options => 
	options.UseNpgsql(builder.Configuration["ConnectionString"] ));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


var app = builder.Build();


if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.MapHealthChecks("/healthz");
app.MatchEndpoints();
app.TournamentEndpoints();
app.TemplateEndpoints();

app.Run();
