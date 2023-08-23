using LinqKit;

using OTP.Domains.Models.Subjects;
using OTP.Dtos.Subjects;
using OTP.Repositories.Interfaces;
using OTP.Services.Subjects.Interfaces;

namespace OTP.Services.Subjects.Implementation
{
	public class CreateSubjectService : ICreateSubjectService
	{
		private readonly IRepository<Subject> _subjectRepository;

		public CreateSubjectService(IRepository<Subject> subjectRepository)
		{
			_subjectRepository = subjectRepository;
		}

		public async Task<int> CreateSubjectAsync(SubjectDTO subjectDTO)
		{
			ExpressionStarter<Subject> predicate = PredicateBuilder.New<Subject>();

			predicate.And(s => s.Id == subjectDTO.Id);

			var subject = await _subjectRepository.GetAsync(predicate);

			if(subject == null)
			{
				subject = new Subject
				{
					Name = subjectDTO.Name,
				};

				await _subjectRepository.AddAsync(subject);

				await _subjectRepository.CommitAsync();
			}
			else
			{
				throw new Exception("Subject already exists");
			}

			return subject.Id;
		}
	}
}
