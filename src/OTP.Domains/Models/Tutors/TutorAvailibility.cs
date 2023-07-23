using OTP.Domains.Models.BaseClasses;
using OTP.Domains.Models.CodedLists;

namespace OTP.Domains.Models.Tutors
{
	public class TutorAvailibility : ModelBase
	{
		public int TutorId { get; set; }

		public int WeekDayId { get; set; }

		public int TimeRangeId { get; set; }

		public Tutor Tutor { get; set; }

		public WeekDay WeekDay { get; set; }

		public TimeRange TimeRange { get; set; }
	}
}
