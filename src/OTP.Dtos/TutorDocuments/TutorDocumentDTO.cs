using System.ComponentModel.DataAnnotations;

using OTP.Dtos.Enums;

namespace OTP.Dtos.TutorDocuments
{
	public class TutorDocumentDTO
	{
		public int TutorId { get; set; }

		public DocumentTypes DocumentType { get; set; }

		[StringLength(100)]
		public string DocumentName { get; set; }

		[StringLength(500)]
		public string DocumentPath { get; set; }
	}
}
