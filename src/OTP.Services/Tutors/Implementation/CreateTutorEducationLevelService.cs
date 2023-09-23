using LinqKit;

using OTP.Domains.Models.ManyToMany;
using OTP.Dtos.TutorEducationLevels;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class CreateTutorEducationLevelService : ICreateTutorEducationLevelService
	{
		private readonly IRepository<TutorEducationLevel> _tutorEducationLevelRepository;

		public CreateTutorEducationLevelService(IRepository<TutorEducationLevel> tutorEducationLevelRepository)
		{
			_tutorEducationLevelRepository = tutorEducationLevelRepository;
		}

		public async Task CreateTutorEducationLevelAsync(int tutorId, ICollection<TutorEducationLevelDTO> tutorEducationLevels)
		{
			ExpressionStarter<TutorEducationLevel> predicate = PredicateBuilder.New<TutorEducationLevel>();

			predicate.And(t => t.TutorId == tutorId);

			var newTutorEducationLevels = new List<TutorEducationLevel>();

			var currentTutorEducationLevels = await _tutorEducationLevelRepository.GetAllAsync(predicate);

			if (currentTutorEducationLevels.Any())
			{
				await _tutorEducationLevelRepository.DeleteRangeAsync(currentTutorEducationLevels.ToList());
			}

			newTutorEducationLevels.AddRange(tutorEducationLevels.Select(tel => new TutorEducationLevel
			{
				EducationLevelId = tel.EducationLevelId,
				TutorId = tutorId,
			}).ToList());

			await _tutorEducationLevelRepository.AddRangeAsync(newTutorEducationLevels.ToList());

			await _tutorEducationLevelRepository.CommitAsync();
		}
	}
}
