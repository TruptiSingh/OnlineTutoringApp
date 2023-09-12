using Microsoft.AspNetCore.Mvc;

using OTP.Dtos.UserDocuments;
using OTP.Services.UserDocuments.Interfaces;

namespace OTP.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class DocumentsController : ControllerBase
	{
		private readonly IGetUserDocumentService _getUserDocumentService;
		private readonly IStoreUserDocumentService _storeUserDocumentService;

		public DocumentsController(IGetUserDocumentService getUserDocumentService,
			IStoreUserDocumentService storeUserDocumentService)
		{
			_getUserDocumentService = getUserDocumentService;
			_storeUserDocumentService = storeUserDocumentService;
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<ICollection<GetUserDocumentsDTO>>> GetUserDocumentsAsync(int userId)
		{
			var userDocuments = await _getUserDocumentService.GetUserDocumentsAsync(userId);

			return Ok(userDocuments);
		}

		[HttpPost]
		public async Task<ActionResult> StoreUserDocumentsAsync(StoreUserFileDTO storeUserFileDTO)
		{
			await _storeUserDocumentService.StoreUserDocumentAsync(storeUserFileDTO);

			return Ok();
		}
	}
}
