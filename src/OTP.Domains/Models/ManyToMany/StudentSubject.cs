using OTP.Domains.Models.BaseClasses;

namespace OTP.Domains.Models.ManyToMany
{
	public class StudentSubject : ModelBase
	{
		public int StudentId { get; set; }

		public int SubjectId { get; set; }
	}
}
