using LinqKit;

using OTP.Domains.Models.Common;
using OTP.Domains.Models.Students;
using OTP.Domains.Models.Tutors;
using OTP.Dtos.Enums;
using OTP.Dtos.UserImages;
using OTP.Repositories.Interfaces;
using OTP.Services.UserImages.Interfaces;

namespace OTP.Services.UserImages.Implementation
{
	public class StoreUserImageService : IStoreUserImageService
	{
		private readonly IRepository<UserImage> _storeUserImageRepository;
		private readonly IRepository<Tutor> _tutorRepository;
		private readonly IRepository<Student> _studentRepository;

		public StoreUserImageService(IRepository<UserImage> storeUserImageRepository,
			IRepository<Tutor> tutorRepository, IRepository<Student> studentRepository)
		{
			_storeUserImageRepository = storeUserImageRepository;
			_tutorRepository = tutorRepository;
			_studentRepository = studentRepository;
		}

		public async Task StoreUserImageAsync(StoreUserImageDTO storeUserImage)
		{
			string userName = "";
			string subDirectoryName = "";

			if (storeUserImage.UserType == UserTypes.Tutor)
			{
				var predicate = PredicateBuilder.New<Tutor>();

				predicate.And(t => t.Id == storeUserImage.UserId);

				var tutor = await _tutorRepository.GetAsync(predicate);

				userName = $"{tutor.FirstName}_{tutor.LastName}";
				subDirectoryName = "TutorImages";
			}
			else if (storeUserImage.UserType == UserTypes.Student)
			{
				var predicate = PredicateBuilder.New<Student>();

				predicate.And(s => s.Id == storeUserImage.UserId);

				var student = await _studentRepository.GetAsync(predicate);

				userName = $"{student.FirstName}_{student.LastName}";
				subDirectoryName = "StudentImages";
			}
			else
			{
				throw new Exception("Invalid user type");
			}

			var fileName = $"{userName}_{storeUserImage.UserId}_{storeUserImage.ImageFile.FileName}.jpg";

			var filePath = Path.Combine(storeUserImage.WebRootPath,
				subDirectoryName, fileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await storeUserImage.ImageFile.CopyToAsync(stream);
			}

			var userImage = new UserImage
			{
				ImageName = fileName,
				ImagePath = filePath,
				UserId = storeUserImage.UserId,
			};

			await _storeUserImageRepository.AddAsync(userImage);

			await _storeUserImageRepository.CommitAsync();
		}
	}
}
