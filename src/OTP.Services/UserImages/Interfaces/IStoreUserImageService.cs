using OTP.Dtos.UserImages;

namespace OTP.Services.UserImages.Interfaces
{
	public interface IStoreUserImageService
	{
		Task StoreUserImageAsync(StoreUserImageDTO storeUserImage);
	}
}
