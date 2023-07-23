using OTP.Utilities.EnumUtilities.Attributes;

namespace OTP.Dtos.Enums
{
	public enum TimeRanges
	{
		[Description("Before_12")]
		Before12 = 1,

		[Description("12_-_5_pm")]
		_12_To_5_PM = 2,

		[Description("After_5_pm")]
		After5PM = 3,
	}
}
