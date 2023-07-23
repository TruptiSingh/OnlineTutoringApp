using OTP.Domains.Models.BaseClasses;

namespace OTP.Domains.Models.ManyToMany
{
	public class TutorEducationLevel : ModelBase
	{
		public int TutorId { get; set; }

		public int EducationLevelId { get; set; }
	}
}
