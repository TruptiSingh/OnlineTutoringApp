using OTP.Dtos.Students;

namespace OTP.Services.Students.Interfaces
{
	public interface ICreateStudentService
	{
		Task<int> CreateStudentAsync(CreateStudentDTO createStudentDTO);
	}
}
