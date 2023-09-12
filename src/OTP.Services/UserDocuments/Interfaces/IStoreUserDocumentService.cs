using OTP.Dtos.UserDocuments;

namespace OTP.Services.UserDocuments.Interfaces
{
	public interface IStoreUserDocumentService
	{
		Task StoreUserDocumentAsync(StoreUserFileDTO storeUserFile);
	}
}
