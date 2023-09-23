namespace OTP.Dtos.Tutors
{
	public class GetTutorAvailibilityDTO
	{
		public int TutorId { get; set; }

		public string WeekDay { get; set; }

		public string TimeRange { get; set; }
	}
}
