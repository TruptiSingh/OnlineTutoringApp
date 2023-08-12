using OTP.Dtos.Subjects;

namespace OTP.Services.Subjects.Interfaces
{
	public interface ICreateSubjectService
	{
		Task<int> CreateSubjectAsync(SubjectDTO subjectDTO);
	}
}
