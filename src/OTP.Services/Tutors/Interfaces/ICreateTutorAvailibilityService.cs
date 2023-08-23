using OTP.Dtos.Tutors;

namespace OTP.Services.Tutors.Interfaces
{
	public interface ICreateTutorAvailibilityService
	{
		Task CreateTutorAvailibilityAsync(int tutorId, ICollection<TutorAvailibilityDTO> createTutorAvailibilityDTOs);
	}
}
