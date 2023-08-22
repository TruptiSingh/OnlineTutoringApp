using LinqKit;

using OTP.Domains.Models.ManyToMany;
using OTP.Domains.Models.Students;
using OTP.Dtos.Students;
using OTP.Repositories.Interfaces;
using OTP.Services.Students.Interfaces;

namespace OTP.Services.Students.Implementation
{
	public class CreateStudentService : ICreateStudentService
	{
		private readonly IRepository<Student> _studentRepository;
		private readonly IRepository<StudentSubject> _studentSubjectRepository;

		public CreateStudentService(IRepository<Student> studentRepository,
			IRepository<StudentSubject> studentSubjectRepository)
		{
			_studentRepository = studentRepository;
			_studentSubjectRepository = studentSubjectRepository;
		}

		public async Task<int> CreateStudentAsync(CreateStudentDTO createStudentDTO)
		{
			int id = 0;

			var predicate = PredicateBuilder.New<Student>();

			predicate.And(s => s.LinkedUserId == createStudentDTO.LinkedUserId);

			using(var transaction = await _studentRepository.StartTransactionAsync())
			{
				var student = await _studentRepository.GetAsync(predicate);

				if(student == null)
				{
					student = new Student
					{
						EducationLevelId = createStudentDTO.EducationLevelId,
						LinkedUserId = createStudentDTO.LinkedUserId,
					};

					await _studentRepository.AddAsync(student);

					await _studentRepository.CommitAsync();

					var studentSubjects = new List<StudentSubject>();

					foreach(var studentSubjectDTO in createStudentDTO.StudentSubjects)
					{
						var studentSubject = new StudentSubject
						{
							StudentId = student.Id,
							SubjectId = studentSubjectDTO.SubjectId,
						};

						studentSubjects.Add(studentSubject);
					}

					await _studentSubjectRepository.AddRangeAsync(studentSubjects);

					await _studentSubjectRepository.CommitAsync();

					await transaction.CommitAsync();

					id = student.Id;
				}
				else
				{
					throw new Exception("Student already exists");
				}
			}

			await _studentRepository.SP("dbo.uspSetStudentDataFromIdentityServerData");

			return id;
		}
	}
}
