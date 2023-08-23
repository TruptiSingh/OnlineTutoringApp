using Microsoft.AspNetCore.Mvc;

using OTP.Dtos.Students;
using OTP.Services.Students.Interfaces;

using System.Net;

namespace OTP.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly ICreateStudentService _createStudentService;
		private readonly IGetStudentService _getStudentService;

		public StudentsController(ICreateStudentService createStudentService,
			IGetStudentService getStudentService)
		{
			_createStudentService = createStudentService;
			_getStudentService = getStudentService;
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<GetStudentDTO>> GetStudentByIdAsync(int id)
		{
			try
			{
				return await _getStudentService.GetStudentByIdAsync(id);
			}
			catch(Exception)
			{
				return NotFound();
			}
		}

		[HttpGet("{linkedUserId:string}")]
		public async Task<ActionResult<GetStudentDTO>> GetStudentByLinkedUserIdAsync(string linkedUserId)
		{
			try
			{
				return await _getStudentService.GetStudentByLinkedUserIdAsync(linkedUserId);
			}
			catch(Exception)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateStudentAsync(CreateStudentDTO createStudent)
		{
			try
			{
				return Ok(await _createStudentService.CreateStudentAsync(createStudent));
			}
			catch(Exception)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured while creating a student. Please contact support.");
			}
		}
	}
}
