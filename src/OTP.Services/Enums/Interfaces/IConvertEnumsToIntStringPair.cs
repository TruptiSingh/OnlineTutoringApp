using OTP.Dtos.BasicObjects;

namespace OTP.Services.Enums.Interfaces
{
	/// <summary>
	/// Interface that provides the facility to convert an enum text and corresponding value to int string pair
	/// </summary>
	public interface IConvertEnumsToIntStringPair
	{
		/// <summary>
		/// Converts an enum text and corresponding value to int string pair
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		List<IntStringPair> ConvertEnumToIntStringPair<T>() where T : Enum;
	}
}
