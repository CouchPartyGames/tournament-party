namespace CouchParty.TournamentBackend.Data;

public sealed class TournamentContext : DbContext {

	public DbSet<Tournament> Tournament { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder options) {
		options.UseSqlite($"data source=tourny.db");
		//options.UseInMemoryDatabase(databaseName: "tournamenttime");
		//options.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw")
	}

}
