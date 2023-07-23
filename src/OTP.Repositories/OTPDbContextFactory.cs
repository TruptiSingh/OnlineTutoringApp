using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OTP.Repositories
{
	public class OTPDbContextFactory : IDesignTimeDbContextFactory<OTPDbContext>
	{
		public OTPDbContext CreateDbContext(string [] args)
		{
			IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "OTP.Api"))
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json", optional: true);

			IConfigurationRoot configuration = builder.Build();

			var optionsBuilder = new DbContextOptionsBuilder<OTPDbContext>();

			var connectionString = configuration.GetConnectionString("DefaultConnection");

			// var connectionString = "Server=.\\SQLExpress;Database=OnlineTutoringPlatform;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"; ;

			optionsBuilder.UseSqlServer(connectionString);

			return new OTPDbContext(optionsBuilder.Options);
		}
	}
}
