using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OTP.Dtos.Tutors;
using OTP.Services.Tutors.Interfaces;

using System.Net;

namespace OTP.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class TutorsController : ControllerBase
	{
		private readonly IGetTutorAvailibilityService _getTutorAvailibilityService;
		private readonly ICreateTutorService _createTutorService;

		public TutorsController(IGetTutorAvailibilityService getTutorAvailibilityService,
			ICreateTutorService createTutorService)
		{
			_getTutorAvailibilityService = getTutorAvailibilityService;
			_createTutorService = createTutorService;
		}

		[HttpGet("TutorAvailibility/{tutorId}")]
		[Authorize]
		public async Task<ActionResult<List<TutorAvailibilityDTO>>> GetTutorAvailibilityAsync(int tutorId)
		{
			try
			{
				return Ok(await _getTutorAvailibilityService.GetTutorAvailibilityAsync(tutorId));
			}
			catch(Exception)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateTutorAsync(CreateOrUpdateTutorDTO tutorDTO)
		{
			try
			{
				int id = await _createTutorService.CreateTutorAsync(tutorDTO);

				return Ok(id);
			}
			catch(Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured while creating a tutor. Please contact support.");
			}
		}
	}
}
