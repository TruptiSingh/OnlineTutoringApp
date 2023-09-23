namespace OTP.Dtos.Students
{
	public class CreateStudentDTO
	{
		public CreateStudentDTO()
		{
			StudentSubjects = new List<StudentSubjectDTO>();

		}

		public string LinkedUserId { get; set; }

		public int EducationLevelId { get; set; }

		public ICollection<StudentSubjectDTO> StudentSubjects { get; set; }
	}
}
