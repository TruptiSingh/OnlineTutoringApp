using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.Tutors;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class SetTutorAvailibility : ISetTutorAvailibility
	{
		private readonly IRepository<TutorAvailibility> _tutorAvailibilityRepository;

		public SetTutorAvailibility(IRepository<TutorAvailibility> tutorAvailibilityRepository)
		{
			_tutorAvailibilityRepository = tutorAvailibilityRepository;
		}

		public async Task SetTutorAvailibilityAsync(int tutorId, ICollection<SetTutorAvailibilityDTO> setTutorAvailibilityDTOs)
		{
			ExpressionStarter<TutorAvailibility> predicate = PredicateBuilder.New<TutorAvailibility>();

			predicate.And(t => t.TutorId == tutorId);

			var tutorAvailibilities = await _tutorAvailibilityRepository.GetAllAsync(predicate, includes: ta => ta.Tutor);

			if (tutorAvailibilities.Any())
			{
				await _tutorAvailibilityRepository.DeleteRangeAsync(tutorAvailibilities.ToList());
			}


			throw new NotImplementedException();
		}
	}
}
