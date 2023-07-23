using System.ComponentModel.DataAnnotations;

using OTP.Domains.Models.BaseClasses;
using OTP.Dtos.Enums;

namespace OTP.Domains.Models.Tutors
{
	public class TutorDocument : ModelBase
	{
		public int TutorId { get; set; }

		public DocumentTypes DocumentType { get; set; }

		[StringLength(100)]
		public string DocumentName { get; set; }

		[StringLength(500)]
		public string DocumentPath { get; set; }

		public Tutor Tutor { get; set; }
	}
}
