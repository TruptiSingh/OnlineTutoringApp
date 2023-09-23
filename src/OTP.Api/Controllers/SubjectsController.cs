using Microsoft.AspNetCore.Mvc;

using OTP.Services.Subjects.Interfaces;

namespace OTP.Api.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class SubjectsController : ControllerBase
	{
		private readonly IGetSubjectService _getSubjectService;

		public SubjectsController(IGetSubjectService getSubjectService)
		{
			_getSubjectService = getSubjectService;
		}

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var subjects = await _getSubjectService.GetAllSubjectsAsync();

			if (subjects.Any())
			{
				return Ok(subjects);
			}
			else
			{
				return NotFound();
			}
		}
	}
}
