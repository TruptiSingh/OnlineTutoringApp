using OTP.Dtos.Tutors;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IGetTuorService
	{
		Task<GetTutorDTO> GetTutorByIdAsync(int tutorId);

		Task<ICollection<SearchTutorResponseDto>> GetTutorsBySearchCriteria(SearchTutorRequestDto searchTutorRequest);
	}
}
