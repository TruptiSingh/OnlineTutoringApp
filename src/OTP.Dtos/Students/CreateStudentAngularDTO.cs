namespace OTP.Dtos.Students
{
	public class CreateStudentAngularDTO
	{
		public string LinkedUserId { get; set; }

		public int EducationLevelId { get; set; }

		public ICollection<int> StudentSubjects { get; set; }
	}
}
