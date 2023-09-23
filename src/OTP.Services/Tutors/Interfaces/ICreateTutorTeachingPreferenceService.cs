using OTP.Dtos.TutorTeachingPreferences;

namespace OTP.Services.Tutors.Interfaces
{
	public interface ICreateTutorTeachingPreferenceService
	{
		Task CreateTutorTeachingPreferenceAsync(int tutorId, ICollection<TutorTeachingPreferenceDTO> tutorTeachingPreferences);
	}
}
