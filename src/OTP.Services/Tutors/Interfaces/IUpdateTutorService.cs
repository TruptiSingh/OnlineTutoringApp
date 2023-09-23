using OTP.Dtos.Tutors;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IUpdateTutorService
	{
		Task UpdateTutorAsync(UpdateTutorAngularDTO updateTutorAngularDTO);
	}
}
