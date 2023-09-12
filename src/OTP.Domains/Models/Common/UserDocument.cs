using System.ComponentModel.DataAnnotations;

using OTP.Domains.Models.BaseClasses;

namespace OTP.Domains.Models.Common
{
	public class UserDocument : ModelBase
	{
		public int UserId { get; set; }

		[StringLength(100)]
		public string DocumentName { get; set; }

		[StringLength(500)]
		public string DocumentPath { get; set; }

		public int DocumentType { get; set; }
	}
}
