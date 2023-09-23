using System.ComponentModel.DataAnnotations;

using OTP.Domains.Models.BaseClasses;
using OTP.Domains.Models.Students;
using OTP.Domains.Models.Tutors;

namespace OTP.Domains.Models.Subjects
{
	public class Subject : ModelBase
	{
		[StringLength(100)]
		public string Name { get; set; }

		public ICollection<Tutor> Tutors { get; set; }

		public ICollection<Student> Students { get; set; }
	}
}
