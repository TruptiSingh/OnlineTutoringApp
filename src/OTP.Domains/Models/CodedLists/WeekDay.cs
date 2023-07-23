using System.ComponentModel.DataAnnotations;

using OTP.Domains.Models.BaseClasses;

namespace OTP.Domains.Models.CodedLists
{
	public class WeekDay : ModelBase
	{
		[StringLength(10)]
		public string Name { get; set; }
	}
}
