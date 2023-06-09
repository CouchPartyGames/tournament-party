namespace CouchParty.TournamentBackend.Data;

public sealed class TournamentContext : DbContext {

	public DbSet<Tournament> Tournament { get; set; }

	public DbSet<Match> Match { get; set; }

	public TournamentContext(DbContextOptions options) : base(options) {}

}
