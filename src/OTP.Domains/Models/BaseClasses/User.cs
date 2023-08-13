using OTP.Domains.Models.CodedLists;

using System.ComponentModel.DataAnnotations;

namespace OTP.Domains.Models.BaseClasses
{
	public class User : ModelBase
	{
		[StringLength(50)]
		public string FirstName { get; set; }

		[StringLength(50)]
		public string LastName { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		[StringLength(15)]
		public string PhoneNumber { get; set; }

		[StringLength(200)]
		public string Address1 { get; set; }

		[StringLength(200)]
		public string Address2 { get; set; }

		[StringLength(200)]
		public string Address3 { get; set; }

		[StringLength(100)]
		public string City { get; set; }

		[StringLength(100)]
		public string County { get; set; }

		[StringLength(100)]
		public string Country { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public int? GenderId { get; set; }

		public Gender Gender { get; set; }
	}
}
