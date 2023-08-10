using LinqKit;

using OTP.Domains.Models.ManyToMany;
using OTP.Dtos.TutorSubjects;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class CreateTutorSubjectService : ICreateTutorSubjectService
	{
		private readonly IRepository<TutorSubject> _tutorSubjectRepository;

		public CreateTutorSubjectService(IRepository<TutorSubject> tutorSubjectRepository)
		{
			_tutorSubjectRepository = tutorSubjectRepository;
		}

		public async Task CreateTutorSubjectAsync(int tutorId, ICollection<TutorSubjectDTO> tutorSubjects)
		{
			ExpressionStarter<TutorSubject> predicate = PredicateBuilder.New<TutorSubject>();

			predicate.And(t => t.TutorId == tutorId);

			var newTutorSubjects = new List<TutorSubject>();

			var currentTutorSubjects = await _tutorSubjectRepository.GetAllAsync(predicate);

			using (var transaction = await _tutorSubjectRepository.StartTransactionAsync())
			{
				if (currentTutorSubjects.Any())
				{
					await _tutorSubjectRepository.DeleteRangeAsync(currentTutorSubjects.ToList());
				}

				newTutorSubjects.AddRange(tutorSubjects.Select(ts => new TutorSubject
				{
					SubjectId = ts.SubjectId,
					TutorId = tutorId,
				}).ToList());

				await _tutorSubjectRepository.AddRangeAsync(newTutorSubjects.ToList());

				transaction.Commit();
			}
		}
	}
}
