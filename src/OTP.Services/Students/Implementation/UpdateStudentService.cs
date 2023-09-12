using LinqKit;

using OTP.Domains.Models.ManyToMany;
using OTP.Domains.Models.Students;
using OTP.Dtos.Students;
using OTP.Repositories.Interfaces;
using OTP.Services.Students.Interfaces;

namespace OTP.Services.Students.Implementation
{
	public class UpdateStudentService : IUpdateStudentService
	{
		private readonly IRepository<Student> _studentRepository;
		private readonly IRepository<StudentSubject> _studentSubjectRepository;

		public UpdateStudentService(IRepository<Student> studentRepository,
			IRepository<StudentSubject> studentSubjectRepository)
		{
			_studentRepository = studentRepository;
			_studentSubjectRepository = studentSubjectRepository;
		}


		public async Task UpdateStudentAsync(UpdateStudentAngularDTO updateStudentAngularDTO)
		{
			var predicate = PredicateBuilder.New<Student>();

			predicate.And(s => s.LinkedUserId == updateStudentAngularDTO.LinkedUserId);

			using (var transaction = await _studentRepository.StartTransactionAsync())
			{
				var student = await _studentRepository.GetAsync(predicate);

				if (student == null)
				{
					throw new Exception("Student not found");
				}

				student.EducationLevelId = updateStudentAngularDTO.EducationLevelId;

				await _studentRepository.UpdateAsync(student);

				await _studentRepository.CommitAsync();

				var studentSubjects = new List<StudentSubject>();

				studentSubjects.AddRange(updateStudentAngularDTO.StudentSubjects
					.Select(s => new StudentSubject
					{
						StudentId = student.Id,
						SubjectId = s
					}));

				_studentSubjectRepository.UpdateRange(studentSubjects);

				await _studentSubjectRepository.CommitAsync();

				await transaction.CommitAsync();
			}
		}
	}
}
