using System.ComponentModel.DataAnnotations;

using OTP.Domains.Models.BaseClasses;

namespace OTP.Domains.Models.Common
{
	public class UserImage : ModelBase
	{
		public int UserId { get; set; }

		[StringLength(100)]
		public string ImageName { get; set; }

		[StringLength(500)]
		public string ImagePath { get; set; }
	}
}
