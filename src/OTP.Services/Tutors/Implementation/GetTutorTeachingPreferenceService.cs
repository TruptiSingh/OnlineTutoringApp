using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.TeachingPreferences;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class GetTutorTeachingPreferenceService : IGetTutorTeachingPreferenceService
	{
		private readonly IRepository<Tutor> _tutorRepository;

		public GetTutorTeachingPreferenceService(IRepository<Tutor> tutorRepository)
		{
			_tutorRepository = tutorRepository;
		}

		public async Task<ICollection<TeachingPreferenceDTO>> GetTutorTeachingPreferencesAsync(int tutorId)
		{
			var predicate = PredicateBuilder.New<Tutor>();

			predicate.And(t => t.Id == tutorId);

			var tutor = await _tutorRepository.GetAsync(predicate, t => t.TeachingPreferences);

			return tutor.TeachingPreferences.ToList().Select(tp => new TeachingPreferenceDTO
			{
				Id = tp.Id,
				Name = tp.Name,
			}).ToList();
		}
	}
}
