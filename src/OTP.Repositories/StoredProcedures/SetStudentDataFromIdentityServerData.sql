Create Procedure dbo.uspSetStudentDataFromIdentityServerData

	@LinkedUserId nvarchar(40)

As

	Begin

		Update S

		Set S.Address1 = U.Address1, S.Address2 = U.Address2, S.Address3 = U.Address3, S.City = U.City, S.DateOfBirth = U.DateOfBirth, S.Email = U.Email,
		S.FirstName = U.FirstName, S.GenderId = U.GenderId, S.LastName = U.LastName, S.PhoneNumber = U.PhoneNumber

		From Student S

		Inner Join IdentityServerOTP.dbo.AspNetUsers U On U.Id = S.LinkedUserId

		Where S.LinkedUserId = @LinkedUserId

	End

Go
