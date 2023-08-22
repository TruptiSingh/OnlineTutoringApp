namespace OTP.Services.UserImages.Interfaces
{
	public interface IGetUserImageService
	{
		Task<Tuple<string, string>> GetUserImagePath(int userId);
	}
}
