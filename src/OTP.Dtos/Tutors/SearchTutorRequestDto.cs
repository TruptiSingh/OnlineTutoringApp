namespace OTP.Dtos.Tutors
{
	public class SearchTutorRequestDto
	{
		public string City { get; set; }

		public List<int> TeachingPreferenceIds { get; set; }

		public List<int> SubjectIds { get; set; }

		public int? LevelId { get; set; }

		public List<int> AvailableDayIds { get; set; }

		public decimal? MinPrice { get; set; }

		public decimal? MaxPrice { get; set; }

		public int? GenderId { get; set; }
	}
}
