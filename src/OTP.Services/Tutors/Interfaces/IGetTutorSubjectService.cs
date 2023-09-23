using OTP.Dtos.Subjects;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IGetTutorSubjectService
	{
		Task<ICollection<SubjectDTO>> GetTutorSubjectsAsync(int tutorId);
	}
}
