using Microsoft.AspNetCore.Mvc;

using OTP.Dtos.Enums;
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
		private readonly IWebHostEnvironment _hostingEnvironment;

		public ImagesController(IGetUserImageService getUserImageService,
			IStoreUserImageService storeUserImageService,
			IWebHostEnvironment hostingEnvironment)
		{
			_getUserImageService = getUserImageService;
			_storeUserImageService = storeUserImageService;
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetUserImageAsync(int userId)
		{
			var image = await _getUserImageService.GetUserImageAsync(userId);

			return File(image, "image/jpeg");
		}

		[HttpPost]
		public async Task<IActionResult> StoreUserImageAsync()
		{
			var file = Request.Form.Files [0];
			var userId = Request.Form ["userId"];
			var userType = Request.Form ["userType"];

			StoreUserImageDTO storeUserImageDTO = new()
			{
				ImageFile = file,
				UserId = int.Parse(userId),
				UserType = Enum.Parse<UserTypes>(userType),
				WebRootPath = _hostingEnvironment.WebRootPath
			};

			await _storeUserImageService.StoreUserImageAsync(storeUserImageDTO);

			return Ok();
		}
	}
}
