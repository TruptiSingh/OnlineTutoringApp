using OTP.Dtos.TutorSubjects;

namespace OTP.Services.Tutors.Interfaces
{
	public interface ICreateTutorSubjectService
	{
		Task CreateTutorSubjectAsync(int tutorId, ICollection<TutorSubjectDTO> tutorSubjects);
	}
}
