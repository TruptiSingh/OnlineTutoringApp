using OTP.Dtos.Tutors;

namespace OTP.Services.Tutors.Interfaces
{
	public interface ISetTutorAvailibility
	{
		Task SetTutorAvailibilityAsync(int tutorId, ICollection<SetTutorAvailibilityDTO> setTutorAvailibilityDTOs);
	}
}
