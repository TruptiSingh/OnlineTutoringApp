using System.ComponentModel.DataAnnotations;

using OTP.Domains.Models.BaseClasses;
using OTP.Domains.Models.Tutors;

namespace OTP.Domains.Models.CodedLists
{
	public class TeachingPreference : ModelBase
	{
		[StringLength(50)]
		public string Name { get; set; }

		public ICollection<Tutor> Tutors { get; set; }
	}
}
