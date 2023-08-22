namespace OTP.Dtos.Tutors
{
	public class SearchTutorResponseDto
	{
		public int TutorId { get; set; }

		public string Name { get; set; }

		public decimal HourlyRate { get; set; }

		public decimal? Rating { get; set; }

		public string TutorImagePath { get; set; }

		public string TutorImageName { get; set; }
	}
}
