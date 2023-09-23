using OTP.Dtos.UserDocuments;

namespace OTP.Services.UserDocuments.Interfaces
{
	public interface IGetUserDocumentService
	{
		Task<ICollection<GetUserDocumentsDTO>> GetUserDocumentsAsync(int userId);
	}
}
