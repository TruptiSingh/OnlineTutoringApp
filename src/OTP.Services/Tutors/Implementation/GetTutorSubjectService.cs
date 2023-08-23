using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.Subjects;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class GetTutorSubjectService : IGetTutorSubjectService
	{
		private readonly IRepository<Tutor> _tutorRepository;

		public GetTutorSubjectService(IRepository<Tutor> tutorRepository)
		{
			_tutorRepository = tutorRepository;
		}

		public async Task<ICollection<SubjectDTO>> GetTutorSubjectsAsync(int tutorId)
		{
			var predicate = PredicateBuilder.New<Tutor>();

			predicate.And(t => t.Id == tutorId);

			var tutor = await _tutorRepository.GetAsync(predicate, t => t.Subjects);

			return tutor.Subjects.ToList().Select(s => new SubjectDTO
			{
				Id = s.Id,
				Name = s.Name,
			}).ToList();
		}
	}
}
