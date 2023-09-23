namespace OTP.Dtos.Tutors
{
	public class UpdateTutorAngularDTO
	{
		public string LinkedUserId { get; set; }

		public string Bio { get; set; }

		public string Introduction { get; set; }

		public decimal PricePerHour { get; set; }

		public ICollection<int> TutorEducationLevels { get; set; }

		public ICollection<int> TutorSubjects { get; set; }

		public ICollection<int> TutorTeachingPreferences { get; set; }

		public ICollection<TutorAvailibilityDTO> TutorAvailibilities { get; set; }
	}
}
