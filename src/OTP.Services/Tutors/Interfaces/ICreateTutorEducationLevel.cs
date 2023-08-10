using OTP.Dtos.TutorEducationLevels;

namespace OTP.Services.Tutors.Interfaces
{
	public interface ICreateTutorEducationLevel
	{
		Task CreateTutorEducationLevelAsync(int tutorId, ICollection<TutorEducationLevelDTO> tutorEducationLevels);
	}
}
