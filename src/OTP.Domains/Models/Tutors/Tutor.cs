using OTP.Domains.Models.BaseClasses;
using OTP.Domains.Models.CodedLists;
using OTP.Domains.Models.Subjects;

namespace OTP.Domains.Models.Tutors
{
	public class Tutor : ModelBase
	{
		public int LinkedUserId { get; set; }

		public decimal PricePerHour { get; set; }

		public bool EnhancedDBSChecked { get; set; }

		public bool RightToWorkVerified { get; set; }

		public ICollection<Subject> Subjects { get; set; }

		public ICollection<TeachingPreference> TeachingPreferences { get; set; }

		public ICollection<TutorAvailibility> TutorAvailibilities { get; set; }

		public ICollection<EducationLevel> EducationLevels { get; set; }

		public ICollection<TutorDocument> TutorDocuments { get; set; }
	}
}
