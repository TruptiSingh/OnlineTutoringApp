using OTP.Dtos.TutorEducationLevels;

namespace OTP.Services.Tutors.Interfaces
{
	public interface ICreateTutorEducationLevelService
	{
		Task CreateTutorEducationLevelAsync(int tutorId, ICollection<TutorEducationLevelDTO> tutorEducationLevels);
	}
}
