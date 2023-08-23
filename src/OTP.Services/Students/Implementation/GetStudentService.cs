using AutoMapper;

using LinqKit;

using OTP.Domains.Models.Students;
using OTP.Dtos.Students;
using OTP.Repositories.Interfaces;
using OTP.Services.Students.Interfaces;

using System.Linq.Expressions;

namespace OTP.Services.Students.Implementation
{
	public class GetStudentService : IGetStudentService
	{
		private readonly IRepository<Student> _studentRepository;
		private readonly IMapper _mapper;

		public GetStudentService(IRepository<Student> studentRepository,
			IMapper mapper)
		{
			_studentRepository = studentRepository;
			_mapper = mapper;
		}

		public async Task<GetStudentDTO> GetStudentByIdAsync(int id)
		{
			var predicate = PredicateBuilder.New<Student>();

			predicate.And(s => s.Id == id);

			Expression<Func<Student, object>>[] includes = new Expression<Func<Student, object>>[]
				{ s => s.EducationLevel, s => s.Subjects };

			var student = await _studentRepository.GetAsync(predicate, includes);

			var studentDTO = _mapper.Map<GetStudentDTO>(student);

			return studentDTO;
		}

		public async Task<GetStudentDTO> GetStudentByLinkedUserIdAsync(string linkedUserId)
		{
			var predicate = PredicateBuilder.New<Student>();

			predicate.And(s => s.LinkedUserId == linkedUserId);

			Expression<Func<Student, object>>[] includes = new Expression<Func<Student, object>>[]
				{ s => s.EducationLevel, s => s.Subjects };

			var student = await _studentRepository.GetAsync(predicate, includes);

			var studentDTO = _mapper.Map<GetStudentDTO>(student);

			return studentDTO;
		}
	}
}
