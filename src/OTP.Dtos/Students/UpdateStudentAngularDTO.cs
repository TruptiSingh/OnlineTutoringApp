namespace OTP.Dtos.Students
{
	public class UpdateStudentAngularDTO
	{
		public string LinkedUserId { get; set; }

		public int EducationLevelId { get; set; }

		public ICollection<int> StudentSubjects { get; set; }
	}
}
