using LinqKit;

using OTP.Domains.Models.Common;
using OTP.Domains.Models.Students;
using OTP.Domains.Models.Tutors;
using OTP.Dtos.Enums;
using OTP.Dtos.UserDocuments;
using OTP.Repositories.Interfaces;
using OTP.Services.UserDocuments.Interfaces;

namespace OTP.Services.UserDocuments.Implementation
{
	public class StoreUserDocumentService : IStoreUserDocumentService
	{
		private readonly IRepository<UserDocument> _userDocumentRepository;
		private readonly IRepository<Tutor> _tutorRepository;
		private readonly IRepository<Student> _studentRepository;

		public StoreUserDocumentService(IRepository<UserDocument> userDocumentRepository,
			IRepository<Tutor> tutorRepository, IRepository<Student> studentRepository)
		{
			_userDocumentRepository = userDocumentRepository;
			_tutorRepository = tutorRepository;
			_studentRepository = studentRepository;
		}

		public async Task StoreUserDocumentAsync(StoreUserFileDTO storeUserFile)
		{
			string userName = "";
			string subDirectoryName = "";

			if (storeUserFile.UserType == UserTypes.Tutor)
			{
				var predicate = PredicateBuilder.New<Tutor>();

				predicate.And(t => t.Id == storeUserFile.UserId);

				var tutor = await _tutorRepository.GetAsync(predicate);

				userName = $"{tutor.FirstName}_{tutor.LastName}";

				subDirectoryName = "TutorDocuments";
			}
			else if (storeUserFile.UserType == UserTypes.Student)
			{
				var predicate = PredicateBuilder.New<Student>();

				predicate.And(s => s.Id == storeUserFile.UserId);

				var student = await _studentRepository.GetAsync(predicate);

				userName = $"{student.FirstName}_{student.LastName}";
				subDirectoryName = "StudentDocuments";
			}
			else
			{
				throw new Exception("Invalid user type");
			}

			var fileName = $"{userName}_{storeUserFile.UserId}_{storeUserFile.UserDocumentFile.FileName}.pdf";

			var filePath = Path.Combine(storeUserFile.WebRootPath,
				subDirectoryName, fileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await storeUserFile.UserDocumentFile.CopyToAsync(stream);
			}

			var userDocument = new UserDocument
			{
				DocumentName = fileName,
				DocumentPath = filePath,
				UserId = storeUserFile.UserId,
				DocumentType = storeUserFile.DocumentType
			};

			await _userDocumentRepository.AddAsync(userDocument);

			await _userDocumentRepository.CommitAsync();
		}
	}
}
