using OTP.Dtos.Students;

namespace OTP.Services.Students.Interfaces
{
	public interface IUpdateStudentService
	{
		Task UpdateStudentAsync(UpdateStudentAngularDTO updateStudentAngularDTO);
	}
}
