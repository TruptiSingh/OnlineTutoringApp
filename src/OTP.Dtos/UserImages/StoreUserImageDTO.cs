using Microsoft.AspNetCore.Http;

using OTP.Dtos.Enums;

namespace OTP.Dtos.UserImages
{
	public class StoreUserImageDTO
	{
		public int UserId { get; set; }

		public UserTypes UserType { get; set; }

		public string WebRootPath { get; set; }

		public IFormFile ImageFile { get; set; }

		public byte[] Image { get; set; }
	}
}
