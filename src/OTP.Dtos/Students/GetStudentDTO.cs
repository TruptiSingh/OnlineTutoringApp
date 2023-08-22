using OTP.Dtos.EducationLevels;
using OTP.Dtos.Subjects;

namespace OTP.Dtos.Students
{
	public class GetStudentDTO
	{
		public int LinkedUserId { get; set; }

		public int EducationLevelId { get; set; }

		public EducationLevelDTO EducationLevel { get; set; }

		public ICollection<SubjectDTO> Subjects { get; set; }
	}
}
