using OTP.Api.AutoMapper;
using OTP.Repositories.Implementation;
using OTP.Repositories.Interfaces;
using OTP.Services.Enums.Implementation;
using OTP.Services.Enums.Interfaces;
using OTP.Services.Students.Implementation;
using OTP.Services.Students.Interfaces;
using OTP.Services.Subjects.Implementation;
using OTP.Services.Subjects.Interfaces;
using OTP.Services.Tutors.Implementation;
using OTP.Services.Tutors.Interfaces;
using OTP.Services.UserDocuments.Implementation;
using OTP.Services.UserDocuments.Interfaces;
using OTP.Services.UserImages.Implementation;
using OTP.Services.UserImages.Interfaces;

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

			services.AddScoped<IUpdateTutorService, UpdateTutorService>();

			services.AddScoped<ICreateStudentService, CreateStudentService>();

			services.AddScoped<IUpdateStudentService, UpdateStudentService>();

			services.AddScoped<ICreateSubjectService, CreateSubjectService>();

			services.AddScoped<IGetStudentService, GetStudentService>();

			services.AddScoped<IGetSubjectService, GetSubjectService>();

			services.AddScoped<IGetUserImageService, GetUserImageService>();

			services.AddScoped<IStoreUserImageService, StoreUserImageService>();

			services.AddScoped<IGetUserDocumentService, GetUserDocumentService>();

			services.AddScoped<IStoreUserDocumentService, StoreUserDocumentService>();
		}
	}
}
