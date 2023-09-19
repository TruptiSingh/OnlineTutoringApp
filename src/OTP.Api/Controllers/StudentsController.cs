using System.Net;

using Microsoft.AspNetCore.Mvc;

using OTP.Dtos.Students;
using OTP.Services.Students.Interfaces;

namespace OTP.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly ICreateStudentService _createStudentService;
		private readonly IGetStudentService _getStudentService;
		private readonly IUpdateStudentService _updateStudentService;

		public StudentsController(ICreateStudentService createStudentService,
			IGetStudentService getStudentService,
			IUpdateStudentService updateStudentService)
		{
			_createStudentService = createStudentService;
			_getStudentService = getStudentService;
			_updateStudentService = updateStudentService;
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<GetStudentDTO>> GetStudentByIdAsync(int id)
		{
			try
			{
				return await _getStudentService.GetStudentByIdAsync(id);
			}
			catch (Exception)
			{
				return NotFound();
			}
		}

		[HttpGet("LinkedUserId/{linkedUserId}")]
		public async Task<ActionResult<GetStudentDTO>> GetStudentByLinkedUserIdAsync(string linkedUserId)
		{
			try
			{
				return await _getStudentService.GetStudentByLinkedUserIdAsync(linkedUserId);
			}
			catch (Exception)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateStudentAsync(CreateStudentAngularDTO createStudent)
		{
			try
			{
				return Ok(await _createStudentService.CreateStudentAsync(createStudent));
			}
			catch (Exception)
			{
				return StatusCode((int) HttpStatusCode.InternalServerError, "Error occured while creating a student. Please contact support.");
			}
		}

		[HttpPut]
		public async Task<ActionResult> UpdateStudentAsync(UpdateStudentAngularDTO updateStudent)
		{
			try
			{
				await _updateStudentService.UpdateStudentAsync(updateStudent);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode((int) HttpStatusCode.InternalServerError, "Error occured while updating a student. Please contact support.");
			}
		}
	}
}
