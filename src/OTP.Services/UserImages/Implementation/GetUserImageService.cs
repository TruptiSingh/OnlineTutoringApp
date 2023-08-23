using LinqKit;

using OTP.Domains.Models.Common;
using OTP.Repositories.Interfaces;
using OTP.Services.UserImages.Interfaces;

namespace OTP.Services.UserImages.Implementation
{
	public class GetUserImageService : IGetUserImageService
	{
		private readonly IRepository<UserImage> _userImageRepository;

		public GetUserImageService(IRepository<UserImage> userImageRepository)
		{
			_userImageRepository = userImageRepository;
		}

		public async Task<Tuple<string, string>> GetUserImageNameAndPath(int userId)
		{
			var predicate = PredicateBuilder.New<UserImage>();

			predicate.And(ui => ui.UserId == userId);

			var userImage = await _userImageRepository.GetAsync(predicate);

			return Tuple.Create(userImage.ImageName, userImage.ImagePath);
		}

		public async Task<byte[]> GetUserImage(int userId)
		{
			var predicate = PredicateBuilder.New<UserImage>();

			predicate.And(ui => ui.UserId == userId);

			var userImage = await _userImageRepository.GetAsync(predicate);

			byte[] image = File.ReadAllBytes(userImage.ImagePath);

			return image;
		}
	}
}
