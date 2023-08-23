using OTP.Dtos.Students;

namespace OTP.Services.Students.Interfaces
{
	public interface IGetStudentService
	{
		Task<GetStudentDTO> GetStudentByIdAsync(int id);

		Task<GetStudentDTO> GetStudentByLinkedUserIdAsync(string linkedUserId);
	}
}
