using OTP.Domains.Models.BaseClasses;

namespace OTP.Domains.Models.ManyToMany
{
	public class TutorTeachingPreference : ModelBase
	{
		public int TutorId { get; set; }

		public int TeachingPreferenceId { get; set; }
	}
}
