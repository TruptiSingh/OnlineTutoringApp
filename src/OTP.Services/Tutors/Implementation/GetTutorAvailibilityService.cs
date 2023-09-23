using System.Linq.Expressions;

using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.Tutors;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class GetTutorAvailibilityService : IGetTutorAvailibilityService
	{
		private readonly IRepository<TutorAvailibility> _tutorAvailibilityRepository;

		public GetTutorAvailibilityService(IRepository<TutorAvailibility> tutorAvailibilityRepository)
		{
			_tutorAvailibilityRepository = tutorAvailibilityRepository;
		}

		public async Task<ICollection<GetTutorAvailibilityDTO>> GetTutorAvailibilityAsync(int tutorId)
		{
			var predicate = PredicateBuilder.New<TutorAvailibility>();

			predicate.And(t => t.TutorId == tutorId);

			Expression<Func<TutorAvailibility, object>> [] includes = new Expression<Func<TutorAvailibility, object>> []
				{ t => t.TimeRange, t => t.WeekDay };

			var tutorAvailibilities = await _tutorAvailibilityRepository.GetAllAsync(predicate, includes);

			List<GetTutorAvailibilityDTO> tutorAvailibilityDTOs = new();

			tutorAvailibilityDTOs.AddRange(tutorAvailibilities
				.Select(tutorAvailibility => new GetTutorAvailibilityDTO
				{
					TutorId = tutorAvailibility.TutorId,
					TimeRange = tutorAvailibility.TimeRange.Name,
					WeekDay = tutorAvailibility.WeekDay.Name
				}));

			return tutorAvailibilityDTOs;
		}
	}
}
