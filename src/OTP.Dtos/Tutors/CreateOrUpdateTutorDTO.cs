using OTP.Dtos.TutorEducationLevels;
using OTP.Dtos.TutorSubjects;
using OTP.Dtos.TutorTeachingPreferences;

namespace OTP.Dtos.Tutors
{
	public class CreateOrUpdateTutorDTO
	{
		public string LinkedUserId { get; set; }

		public string Bio { get; set; }

		public decimal PricePerHour { get; set; }

		public ICollection<TutorEducationLevelDTO> TutorEducationLevels { get; set; }

		public ICollection<TutorSubjectDTO> TutorSubjects { get; set; }

		public ICollection<TutorTeachingPreferenceDTO> TutorTeachingPreferences { get; set; }

		public ICollection<TutorAvailibilityDTO> TutorAvailibilities { get; set; }
	}
}
