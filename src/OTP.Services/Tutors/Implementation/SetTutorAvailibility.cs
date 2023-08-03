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

			var availibilities = new List<TutorAvailibility>();

			predicate.And(t => t.TutorId == tutorId);

			var tutorAvailibilities = await _tutorAvailibilityRepository.GetAllAsync(predicate, includes: ta => ta.Tutor);

			using (var transaction = await _tutorAvailibilityRepository.StartTransactionAsync())
			{
				if (tutorAvailibilities.Any())
				{
					await _tutorAvailibilityRepository.DeleteRangeAsync(tutorAvailibilities.ToList());
				}

				availibilities.AddRange(setTutorAvailibilityDTOs.Select(ta => new TutorAvailibility
				{
					TutorId = tutorId,
					CreatedDate = DateTime.Now,
					ModifiedDate = DateTime.Now,
					IsDeleted = false,
					TimeRangeId = ta.TimeRangeId,
					WeekDayId = ta.WeekDayId
				}));

				await _tutorAvailibilityRepository.AddRangeAsync(availibilities);

				await transaction.CommitAsync();
			}

			throw new NotImplementedException();
		}
	}
}
