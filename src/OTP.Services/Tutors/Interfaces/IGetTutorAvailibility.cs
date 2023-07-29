using OTP.Dtos.Tutors;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IGetTutorAvailibility
	{
		Task<List<TutorAvailibilityDTO>> GetTutorAvailibilityAsync(int tutorId);
	}
}
