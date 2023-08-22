using OTP.Domains.Models.BaseClasses;
using OTP.Domains.Models.CodedLists;
using OTP.Domains.Models.Subjects;

namespace OTP.Domains.Models.Students
{
	public class Student : User
	{
		public string LinkedUserId { get; set; }

		public int EducationLevelId { get; set; }

		public EducationLevel EducationLevel { get; set; }

		public ICollection<Subject> Subjects { get; set; }
	}
}
