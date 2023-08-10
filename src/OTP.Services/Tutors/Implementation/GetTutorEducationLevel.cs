using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.EducationLevels;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class GetTutorEducationLevel : IGetTutorEducationLevel
	{
		private readonly IRepository<Tutor> _tutorRepository;

		public GetTutorEducationLevel(IRepository<Tutor> tutorRepository)
		{
			_tutorRepository = tutorRepository;
		}

		public async Task<ICollection<EducationLevelDTO>> GetEducationLevels(int tutorId)
		{
			var predicate = PredicateBuilder.New<Tutor>();

			predicate.And(t => t.Id == tutorId);

			var tutor = await _tutorRepository.GetAsync(predicate, t => t.EducationLevels);

			return tutor.EducationLevels.ToList().Select(els => new EducationLevelDTO
			{
				Id = els.Id,
				Name = els.Name,
			}).ToList();
		}
	}
}
