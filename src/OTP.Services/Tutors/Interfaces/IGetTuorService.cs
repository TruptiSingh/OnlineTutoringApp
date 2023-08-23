using OTP.Dtos.Tutors;

namespace OTP.Services.Tutors.Interfaces
{
	public interface IGetTuorService
	{
		Task<GetTutorDTO> GetTutorByIdAsync(int tutorId);

		Task<GetTutorDTO> GetTutorByLinkedUserIdAsync(string linkedUserId);

		Task<ICollection<SearchTutorResponseDTO>> GetTutorsBySearchCriteria(SearchTutorRequestDTO searchTutorRequest);
	}
}
