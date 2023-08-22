using OTP.Dtos.EducationLevels;
using OTP.Dtos.Subjects;
using OTP.Dtos.TeachingPreferences;

namespace OTP.Dtos.Tutors
{
	public class GetTutorDTO
	{
		public int TutorId { get; set; }

		public string LinkedUserId { get; set; }

		public string Introduction { get; set; }

		public string Bio { get; set; }

		public decimal PricePerHour { get; set; }

		public decimal Rating { get; set; }

		public ICollection<EducationLevelDTO> EducationLevels { get; set; }

		public ICollection<SubjectDTO> Subjects { get; set; }

		public ICollection<TeachingPreferenceDTO> TeachingPreferences { get; set; }

		public ICollection<TutorAvailibilityDTO> TutorAvailibilities { get; set; }
	}
}
