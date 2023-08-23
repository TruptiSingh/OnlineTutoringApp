using LinqKit;

using OTP.Domains.Models.ManyToMany;
using OTP.Dtos.TutorTeachingPreferences;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class CreateTutorTeachingPreferenceService : ICreateTutorTeachingPreferenceService
	{
		private readonly IRepository<TutorTeachingPreference> _tutorTeachingPreferenceRepository;

		public CreateTutorTeachingPreferenceService(IRepository<TutorTeachingPreference> tutorTeachingPreferenceRepository)
		{
			_tutorTeachingPreferenceRepository = tutorTeachingPreferenceRepository;
		}

		public async Task CreateTutorTeachingPreferenceAsync(int tutorId, ICollection<TutorTeachingPreferenceDTO> tutorTeachingPreferences)
		{
			ExpressionStarter<TutorTeachingPreference> predicate = PredicateBuilder.New<TutorTeachingPreference>();

			predicate.And(t => t.TutorId == tutorId);

			var newTutorTeachingPreferences = new List<TutorTeachingPreference>();

			var currentTutorTeachingPreferences = await _tutorTeachingPreferenceRepository.GetAllAsync(predicate);

			if (currentTutorTeachingPreferences.Any())
			{
				await _tutorTeachingPreferenceRepository.DeleteRangeAsync(currentTutorTeachingPreferences.ToList());
			}

			newTutorTeachingPreferences.AddRange(tutorTeachingPreferences.Select(ttp => new TutorTeachingPreference
			{
				TeachingPreferenceId = ttp.TeachingPreferenceId,
				TutorId = tutorId,
			}).ToList());

			await _tutorTeachingPreferenceRepository.AddRangeAsync(newTutorTeachingPreferences.ToList());

			await _tutorTeachingPreferenceRepository.CommitAsync();
		}
	}
}
