using OTP.Repositories.Implementation;
using OTP.Repositories.Interfaces;
using OTP.Services.Enums.Implementation;
using OTP.Services.Enums.Interfaces;

namespace OTP.Api.Ioc
{
	public static class IoCInitialise
	{
		public static void Initialise(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			services.AddScoped<IConvertEnumsToIntStringPair, ConvertEnumsToIntStringPair>();
		}
	}
}
