using OTP.Dtos.TutorEducationLevels;
using OTP.Dtos.TutorSubjects;
using OTP.Dtos.TutorTeachingPreferences;

namespace OTP.Dtos.Tutors
{
	public class CreateTutorDTO
	{
		public CreateTutorDTO()
		{
			TutorEducationLevels = new List<TutorEducationLevelDTO>();
			TutorSubjects = new List<TutorSubjectDTO>();
			TutorTeachingPreferences = new List<TutorTeachingPreferenceDTO>();
			TutorAvailibilities = new List<TutorAvailibilityDTO>();
		}

		public string LinkedUserId { get; set; }

		public string Bio { get; set; }

		public string Introduction { get; set; }

		public decimal PricePerHour { get; set; }

		public ICollection<TutorEducationLevelDTO> TutorEducationLevels { get; set; }

		public ICollection<TutorSubjectDTO> TutorSubjects { get; set; }

		public ICollection<TutorTeachingPreferenceDTO> TutorTeachingPreferences { get; set; }

		public ICollection<TutorAvailibilityDTO> TutorAvailibilities { get; set; }
	}
}
