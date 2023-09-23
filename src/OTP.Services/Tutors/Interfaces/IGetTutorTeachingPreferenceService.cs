using OTP.Dtos.TeachingPreferences;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IGetTutorTeachingPreferenceService
	{
		Task<ICollection<TeachingPreferenceDTO>> GetTutorTeachingPreferencesAsync(int tutorId);
	}
}
