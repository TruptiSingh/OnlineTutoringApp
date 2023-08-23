using OTP.Dtos.Students;

namespace OTP.Services.Students.Interfaces
{
	public interface IGetStudentService
	{
		Task<GetStudentDTO> GetStudentById(int id);

		Task<GetStudentDTO> GetStudentByLinkedUserId(string linkedUserId);
	}
}
