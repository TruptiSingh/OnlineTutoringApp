namespace OTP.Services.UserImages.Interfaces
{
	public interface IGetUserImageService
	{
		Task<Tuple<string, string>> GetUserImageNameAndPath(int userId);

		Task<byte[]> GetUserImage(int userId);
	}
}
