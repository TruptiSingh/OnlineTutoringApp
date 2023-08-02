using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OTP.Dtos.Tutors;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class TutorsController : ControllerBase
	{
		private readonly IGetTutorAvailibility _getTutorAvailibility;

		public TutorsController(IGetTutorAvailibility getTutorAvailibility)
		{
			_getTutorAvailibility = getTutorAvailibility;
		}

		[HttpGet("TutorAvailibility/{tutorId}")]
		[Authorize]
		public async Task<ActionResult<List<GetTutorAvailibilityDTO>>> GetTutorAvailibilityAsync(int tutorId)
		{
			try
			{
				return Ok(await _getTutorAvailibility.GetTutorAvailibilityAsync(tutorId));
			}
			catch (Exception)
			{
				return NotFound();
			}
		}
	}
}
