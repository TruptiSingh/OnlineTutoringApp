using OTP.Dtos.Tutors;

namespace OTP.Services.Tutors.Interfaces
{
	public interface ICreateTutorService
	{
		Task<int> CreateTutorAsync(CreateOrUpdateTutorDTO tutorDTO);
	}
}
