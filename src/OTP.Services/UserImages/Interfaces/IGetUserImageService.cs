namespace OTP.Services.UserImages.Interfaces
{
	public interface IGetUserImageService
	{
		Task<Tuple<string, string>> GetUserImageNameAndPathAsync(int userId);

		Task<byte []> GetUserImageAsync(int userId);
	}
}
