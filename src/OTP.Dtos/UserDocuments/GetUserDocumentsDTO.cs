namespace OTP.Dtos.UserDocuments
{
	public class GetUserDocumentsDTO
	{
		public int UserId { get; set; }

		public string DocumentName { get; set; }

		public string DocumentPath { get; set; }

		public int DocumentType { get; set; }
	}
}
