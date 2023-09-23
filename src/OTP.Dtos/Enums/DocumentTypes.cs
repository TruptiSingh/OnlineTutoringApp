using OTP.Utilities.EnumUtilities.Attributes;

namespace OTP.Dtos.Enums
{
	public enum DocumentTypes
	{
		[Description("Proof_Of_Address")]
		ProofOfAddress = 1,

		[Description("Proof_Of_Id")]
		ProofOfId = 2,

		[Description("Proof_Of_DBS")]
		ProofOfDBS = 3,

		[Description("Proof_Of_Eligibility_To_Work")]
		ProofOfEligibilityToWork = 4,
	}
}
