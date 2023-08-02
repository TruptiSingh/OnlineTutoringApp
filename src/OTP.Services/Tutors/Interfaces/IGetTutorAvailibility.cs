using OTP.Dtos.Tutors;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IGetTutorAvailibility
	{
		Task<List<GetTutorAvailibilityDTO>> GetTutorAvailibilityAsync(int tutorId);
	}
}
