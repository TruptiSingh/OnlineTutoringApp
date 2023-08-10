using OTP.Dtos.EducationLevels;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IGetTutorEducationLevel
	{
		Task<ICollection<EducationLevelDTO>> GetEducationLevels(int tutorId);
	}
}
