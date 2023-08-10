using OTP.Dtos.Tutors;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IGetTuorService
	{
		Task<TutorDTO> GetTutorById(int tutorId);
	}
}
