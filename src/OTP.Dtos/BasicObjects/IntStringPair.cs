namespace OTP.Dtos.BasicObjects
{
	public class IntStringPair
	{
		#region Public Constructor

		/// <summary>
		/// Public Constructor
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public IntStringPair(int key, string value)
		{
			Key = key;
			Value = value;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Integer Key
		/// </summary>
		public int Key { get; set; }

		/// <summary>
		/// String Value
		/// </summary>
		public string Value { get; set; }

		#endregion
	}
}
