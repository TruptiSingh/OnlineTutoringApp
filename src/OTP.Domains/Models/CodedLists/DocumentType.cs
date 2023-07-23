using System.ComponentModel.DataAnnotations;

using OTP.Domains.Models.BaseClasses;

namespace OTP.Domains.Models.CodedLists
{
	public class DocumentType : ModelBase
	{
		[StringLength(50)]
		public string Name { get; set; }
	}
}
