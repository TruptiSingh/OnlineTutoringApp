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
		private readonly IGetTuorService _getTuorService;

		public TutorsController(IGetTutorAvailibilityService getTutorAvailibilityService,
			ICreateTutorService createTutorService,
			IGetTuorService getTuorService)
		{
			_getTutorAvailibilityService = getTutorAvailibilityService;
			_createTutorService = createTutorService;
			_getTuorService = getTuorService;
		}

		[HttpGet("TutorAvailibility/{tutorId}")]
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

		[HttpGet("{id}")]
		public async Task<ActionResult<GetTutorDTO>> GetTutorByIdAsync(int id)
		{
			try
			{
				return Ok(await _getTuorService.GetTutorByIdAsync(id));
			}
			catch(Exception)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateTutorAsync(CreateTutorDTO tutorDTO)
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
