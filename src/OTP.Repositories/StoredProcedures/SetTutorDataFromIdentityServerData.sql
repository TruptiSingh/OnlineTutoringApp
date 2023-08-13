Create Procedure dbo.uspSetTutorDataFromIdentityServerData

	@LinkedUserId nvarchar(40)

As

	Begin

		Update T

		Set T.Address1 = U.Address1, T.Address2 = U.Address2, T.Address3 = U.Address3, T.City = U.City, T.DateOfBirth = U.DateOfBirth, T.Email = U.Email,
		T.FirstName = U.FirstName, T.GenderId = U.GenderId, T.LastName = U.LastName, T.PhoneNumber = U.PhoneNumber

		From Tutor T

		Inner Join IdentityServerOTP.dbo.AspNetUsers U On U.Id = T.LinkedUserId

		Where T.LinkedUserId = @LinkedUserId

	End

Go