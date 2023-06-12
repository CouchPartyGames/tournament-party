namespace CouchParty.TournamentBackend.Data;

using TournamentModel = CouchParty.TournamentBackend.Models.Tournament;
using MatchModel = CouchParty.TournamentBackend.Models.Match;
using TemplateModel = CouchParty.TournamentBackend.Models.Template;

public sealed class TournamentContext : DbContext {

	public DbSet<TournamentModel> Tournament { get; set; }

	public DbSet<MatchModel> Match { get; set; }

	public DbSet<TemplateModel> Template { get; set; }

	public TournamentContext(DbContextOptions options) : base(options) {}

}
