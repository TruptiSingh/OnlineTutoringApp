using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.Tutors;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class CreateTutorAvailibilityService : ICreateTutorAvailibilityService
	{
		private readonly IRepository<TutorAvailibility> _tutorAvailibilityRepository;

		public CreateTutorAvailibilityService(IRepository<TutorAvailibility> tutorAvailibilityRepository)
		{
			_tutorAvailibilityRepository = tutorAvailibilityRepository;
		}

		public async Task CreateTutorAvailibilityAsync(int tutorId, ICollection<TutorAvailibilityDTO> createTutorAvailibilityDTOs)
		{
			ExpressionStarter<TutorAvailibility> predicate = PredicateBuilder.New<TutorAvailibility>();

			var availibilities = new List<TutorAvailibility>();

			predicate.And(t => t.TutorId == tutorId);

			var tutorAvailibilities = await _tutorAvailibilityRepository.GetAllAsync(predicate, includes: ta => ta.Tutor);

			if (tutorAvailibilities.Any())
			{
				await _tutorAvailibilityRepository.DeleteRangeAsync(tutorAvailibilities.ToList());
			}

			availibilities.AddRange(createTutorAvailibilityDTOs.Select(ta => new TutorAvailibility
			{
				TutorId = tutorId,
				TimeRangeId = ta.TimeRangeId,
				WeekDayId = ta.WeekDayId
			}));

			await _tutorAvailibilityRepository.AddRangeAsync(availibilities);

			await _tutorAvailibilityRepository.CommitAsync();
		}
	}
}
