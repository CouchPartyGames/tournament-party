namespace Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

public static class DependencyInjection {

	public static IServiceCollection AddInfastructure(this IServiceCollection services, IConfiguration config) {
   		services.AddDbContext<TournamentContext>(options => 
			options.UseNpgsql(config["ConnectionString"] )
		);

		return services;
	}
}
