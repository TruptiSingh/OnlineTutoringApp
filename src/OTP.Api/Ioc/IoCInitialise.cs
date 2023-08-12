using OTP.Api.AutoMapper;
using OTP.Repositories.Implementation;
using OTP.Repositories.Interfaces;
using OTP.Services.Enums.Implementation;
using OTP.Services.Enums.Interfaces;
using OTP.Services.Tutors.Implementation;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Api.Ioc
{
	public static class IoCInitialise
	{
		public static void Initialise(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			services.AddAutoMapper(typeof(AutoMapperProfile));

			services.AddScoped<IConvertEnumsToIntStringPair, ConvertEnumsToIntStringPair>();

			services.AddScoped<IGetTutorAvailibilityService, GetTutorAvailibilityService>();

			services.AddScoped<ICreateTutorAvailibilityService, CreateTutorAvailibilityService>();

			services.AddScoped<ICreateTutorEducationLevelService, CreateTutorEducationLevelService>();

			services.AddScoped<IGetTutorEducationLevelService, GetTutorEducationLevelService>();

			services.AddScoped<ICreateTutorSubjectService, CreateTutorSubjectService>();

			services.AddScoped<IGetTutorSubjectService, GetTutorSubjectService>();

			services.AddScoped<ICreateTutorTeachingPreferenceService, CreateTutorTeachingPreferenceService>();

			services.AddScoped<IGetTutorTeachingPreferenceService, GetTutorTeachingPreferenceService>();

			services.AddScoped<ICreateTutorService, CreateTutorService>();

			services.AddScoped<IGetTuorService, GetTuorService>();
		}
	}
}
