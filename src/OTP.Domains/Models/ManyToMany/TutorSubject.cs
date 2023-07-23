using OTP.Domains.Models.BaseClasses;

namespace OTP.Domains.Models.ManyToMany
{
	public class TutorSubject : ModelBase
	{
		public int TutorId { get; set; }

		public int SubjectId { get; set; }
	}
}
