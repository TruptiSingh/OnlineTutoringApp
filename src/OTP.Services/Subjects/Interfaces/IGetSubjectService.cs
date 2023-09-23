using OTP.Dtos.Subjects;

namespace OTP.Services.Subjects.Interfaces
{
	public interface IGetSubjectService
	{
		Task<SubjectDTO> GetSubjectByIdAsync(int subjectId);

		Task<ICollection<SubjectDTO>> GetAllSubjectsAsync();
	}
}
