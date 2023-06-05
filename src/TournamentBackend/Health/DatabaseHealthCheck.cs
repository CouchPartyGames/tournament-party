namespace CouchParty.TournamentBackend.Health;


public class DatabaseHealthCheck : IHealthCheck {

	public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken token = new()) {
		return Task.FromResult(HealthCheckResult.Healthy("The startup task has completed."));
	}
}
