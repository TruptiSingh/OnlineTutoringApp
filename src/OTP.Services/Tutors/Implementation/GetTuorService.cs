using AutoMapper;

using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.Tutors;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;
using OTP.Services.UserImages.Interfaces;

using System.Linq.Expressions;

namespace OTP.Services.Tutors.Implementation
{
	public class GetTuorService : IGetTuorService
	{
		private readonly IRepository<Tutor> _tutorRepository;
		private readonly IGetUserImageService _getUserImageService;
		private readonly IMapper _mapper;

		public GetTuorService(IRepository<Tutor> tutorRepository,
			IGetUserImageService getUserImageService,
			IMapper mapper)
		{
			_tutorRepository = tutorRepository;
			_getUserImageService = getUserImageService;
			_mapper = mapper;
		}

		public async Task<GetTutorDTO> GetTutorByIdAsync(int tutorId)
		{
			ExpressionStarter<Tutor> predicate = PredicateBuilder.New<Tutor>();

			predicate.And(t => t.Id == tutorId);

			Expression<Func<Tutor, object>>[] includes = new Expression<Func<Tutor, object>>[]
				{ t => t.EducationLevels, t => t.Subjects, t => t.TeachingPreferences, t => t.TutorAvailibilities };

			var tutor = await _tutorRepository.GetAsync(predicate);

			var getTutorDTO = _mapper.Map<GetTutorDTO>(tutor);

			return getTutorDTO;
		}

		public async Task<GetTutorDTO> GetTutorByLinkedUserIdAsync(string linkedUserId)
		{
			ExpressionStarter<Tutor> predicate = PredicateBuilder.New<Tutor>();

			predicate.And(t => t.LinkedUserId == linkedUserId);

			Expression<Func<Tutor, object>>[] includes = new Expression<Func<Tutor, object>>[]
				{ t => t.EducationLevels, t => t.Subjects, t => t.TeachingPreferences, t => t.TutorAvailibilities };

			var tutor = await _tutorRepository.GetAsync(predicate);

			var getTutorDTO = _mapper.Map<GetTutorDTO>(tutor);

			return getTutorDTO;
		}

		public async Task<ICollection<SearchTutorResponseDTO>> GetTutorsBySearchCriteriaAsync(SearchTutorRequestDTO searchTutorRequest)
		{
			var filter = PredicateBuilder.New<Tutor>();

			filter.And(t => t.IsDeleted == false);

			if(!string.IsNullOrWhiteSpace(searchTutorRequest.City))
			{
				filter.And(t => t.City.ToLower() == searchTutorRequest.City.ToLower());
			}

			if(searchTutorRequest.SubjectIds != null && searchTutorRequest.SubjectIds.Any())
			{
				foreach(var subjectId in searchTutorRequest.SubjectIds)
				{
					filter.And(t => t.Subjects
						.Any(s => s.Id == subjectId));
				}
			}

			if(searchTutorRequest.GenderId.HasValue)
			{
				filter.And(t => t.GenderId == searchTutorRequest.GenderId.Value);
			}

			if(searchTutorRequest.MinPrice.HasValue)
			{
				filter.And(t => t.PricePerHour >= searchTutorRequest.MinPrice.Value);
			}

			if(searchTutorRequest.MaxPrice.HasValue)
			{
				filter.And(t => t.PricePerHour <= searchTutorRequest.MaxPrice.Value);
			}

			if(searchTutorRequest.TeachingPreferenceIds != null && searchTutorRequest.TeachingPreferenceIds.Any())
			{
				foreach(var preferenceId in searchTutorRequest.TeachingPreferenceIds)
				{
					filter.And(t => t.TeachingPreferences
						.Any(ta => ta.Id == preferenceId));
				}
			}

			if(searchTutorRequest.AvailableDayIds != null && searchTutorRequest.AvailableDayIds.Any())
			{
				foreach(var availibilityId in searchTutorRequest.AvailableDayIds)
				{
					filter.And(t => t.TutorAvailibilities
						.Any(ta => ta.WeekDayId == availibilityId));
				}
			}

			if(searchTutorRequest.LevelId.HasValue)
			{
				filter.And(t => t.EducationLevels
					.Any(el => el.Id == searchTutorRequest.LevelId));
			}

			Expression<Func<Tutor, object>>[] includes = { t => t.Subjects,
				t => t.EducationLevels, t => t.TeachingPreferences, t => t.TutorAvailibilities };

			var tutors = await _tutorRepository.GetAllAsync(filter, includes);

			var searchTutorResponse = new List<SearchTutorResponseDTO>();

			foreach(var tutor in tutors)
			{
				var userImage = await _getUserImageService.GetUserImage(tutor.Id);

				searchTutorResponse.Add(new SearchTutorResponseDTO
				{
					HourlyRate = tutor.PricePerHour,
					Introduction = tutor.Introduction,
					Name = $"{tutor.FirstName} {tutor.LastName}",
					Rating = tutor.Rating,
					TutorId = tutor.Id,
					TutorImage = userImage,
				});
			}

			return searchTutorResponse;
		}
	}
}
