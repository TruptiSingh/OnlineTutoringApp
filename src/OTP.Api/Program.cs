
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using OTP.Repositories;

namespace OTP.Api
{
	public class Program
	{
		public static void Main(string [] args)
		{
			var host = CreateHostBuilder(args).Build();

			using (IServiceScope serviceScope = host.Services.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<OTPDbContext>();

				try
				{
					context.Database.Migrate();
				}
				catch (SqlException)
				{

				}
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string [] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}