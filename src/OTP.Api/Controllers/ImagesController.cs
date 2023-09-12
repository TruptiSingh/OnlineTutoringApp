using Microsoft.AspNetCore.Mvc;

using OTP.Dtos.UserImages;
using OTP.Services.UserImages.Interfaces;

namespace OTP.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase
	{
		private readonly IGetUserImageService _getUserImageService;
		private readonly IStoreUserImageService _storeUserImageService;

		public ImagesController(IGetUserImageService getUserImageService,
			IStoreUserImageService storeUserImageService)
		{
			_getUserImageService = getUserImageService;
			_storeUserImageService = storeUserImageService;
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetUserImageAsync(int userId)
		{
			var image = await _getUserImageService.GetUserImageAsync(userId);

			return File(image, "image/jpeg");
		}

		[HttpPost]
		public async Task<IActionResult> StoreUserImageAsync(StoreUserImageDTO storeUserImageDTO)
		{
			await _storeUserImageService.StoreUserImageAsync(storeUserImageDTO);

			return Ok();
		}
	}
}
