using Microsoft.AspNetCore.Http;

using OTP.Dtos.Enums;

namespace OTP.Dtos.UserDocuments
{
	public class StoreUserFileDTO
	{
		public int UserId { get; set; }

		public UserTypes UserType { get; set; }

		public DocumentTypes DocumentType { get; set; }

		public string WebRootPath { get; set; }

		public IFormFile UserDocumentFile { get; set; }

		public byte [] DocumentFile { get; set; }
	}
}
