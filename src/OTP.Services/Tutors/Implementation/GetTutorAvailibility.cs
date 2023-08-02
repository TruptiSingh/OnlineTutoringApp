using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.Tutors;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class GetTutorAvailibility : IGetTutorAvailibility
	{
		private readonly IRepository<Tutor> _tutorRepository;

		public GetTutorAvailibility(IRepository<Tutor> tutorRepository)
		{
			_tutorRepository = tutorRepository;
		}

		public async Task<List<GetTutorAvailibilityDTO>> GetTutorAvailibilityAsync(int tutorId)
		{
			ExpressionStarter<Tutor> predicate = PredicateBuilder.New<Tutor>();

			predicate.And(t => t.Id == tutorId);

			var tutor = await _tutorRepository.GetAsync(predicate, t => t.TutorAvailibilities);

			List<GetTutorAvailibilityDTO> tutorAvailibilityDTOs = new();

			tutorAvailibilityDTOs.AddRange(tutor.TutorAvailibilities
				.Select(tutorAvailibility => new GetTutorAvailibilityDTO
				{
					TutorId = tutor.Id,
					TimeRange = tutorAvailibility.TimeRange.Name,
					WeekDay = tutorAvailibility.WeekDay.Name
				}));

			return tutorAvailibilityDTOs;
		}
	}
}
