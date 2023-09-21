namespace OTP.Dtos.Tutors
{
	public class SearchTutorResponseDTO
	{
		public int TutorId { get; set; }

		public string Name { get; set; }

		public decimal HourlyRate { get; set; }

		public string Introduction { get; set; }

		public decimal? Rating { get; set; }

		public byte [] TutorImage { get; set; }
	}
}
