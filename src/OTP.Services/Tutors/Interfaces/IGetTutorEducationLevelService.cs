using OTP.Dtos.EducationLevels;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IGetTutorEducationLevelService
	{
		Task<ICollection<EducationLevelDTO>> GetEducationLevelsAsync(int tutorId);
	}
}
