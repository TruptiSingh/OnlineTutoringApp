using LinqKit;

using OTP.Domains.Models.Subjects;
using OTP.Dtos.Subjects;
using OTP.Repositories.Interfaces;
using OTP.Services.Subjects.Interfaces;

namespace OTP.Services.Subjects.Implementation
{
	public class GetSubjectService : IGetSubjectService
	{
		private readonly IRepository<Subject> _subjectRepository;

		public GetSubjectService(IRepository<Subject> subjectRepository)
		{
			_subjectRepository = subjectRepository;
		}

		public async Task<ICollection<SubjectDTO>> GetAllSubjectsAsync()
		{
			ExpressionStarter<Subject> predicate = PredicateBuilder.New<Subject>();

			var subjectDTOs = new List<SubjectDTO>();

			predicate.And(s => !s.IsDeleted);

			var subjects = await _subjectRepository.GetAllAsync(predicate);

			subjectDTOs.AddRange(subjects.Select(s => new SubjectDTO
			{
				Id = s.Id,
				Name = s.Name,
			}));

			return subjectDTOs;
		}

		public async Task<SubjectDTO> GetSubjectByIdAsync(int subjectId)
		{
			ExpressionStarter<Subject> predicate = PredicateBuilder.New<Subject>();

			predicate.And(s => s.Id == subjectId);

			var subject = await _subjectRepository.GetAsync(predicate);

			if(subject != null)
			{
				return new SubjectDTO
				{
					Id = subject.Id,
					Name = subject.Name,
				};
			}
			else
			{
				return null;
			}
		}
	}
}
