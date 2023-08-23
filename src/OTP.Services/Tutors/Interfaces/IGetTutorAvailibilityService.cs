using OTP.Dtos.Tutors;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IGetTutorAvailibilityService
	{
		Task<ICollection<GetTutorAvailibilityDTO>> GetTutorAvailibilityAsync(int tutorId);
	}
}
