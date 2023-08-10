using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.Tutors;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class CreateTutorService : ICreateTutorService
	{
		private readonly IRepository<Tutor> _tutorRepository;
		//private readonly IRepository<TutorEducationLevel> _tutorEducationLevelRepository;
		//private readonly IRepository<TutorSubject> _tutorSubjectRepository;
		//private readonly IRepository<TutorTeachingPreference> _tutorTeachingPreferenceRepository;
		//private readonly IMapper _mapper;

		public CreateTutorService(IRepository<Tutor> tutorRepository)
		//IRepository<TutorEducationLevel> tutorEducationLevelRepository,
		//IRepository<TutorSubject> tutorSubjectRepository,
		//IRepository<TutorTeachingPreference> tutorTeachingPreferenceRepository,
		//IMapper mapper)
		{
			_tutorRepository = tutorRepository;
			//_tutorEducationLevelRepository = tutorEducationLevelRepository;
			//_tutorSubjectRepository = tutorSubjectRepository;
			//_tutorTeachingPreferenceRepository = tutorTeachingPreferenceRepository;
			//_mapper = mapper;
		}

		public async Task<int> CreateTutorAsync(TutorDTO tutorDTO)
		{
			ExpressionStarter<Tutor> predicate = PredicateBuilder.New<Tutor>();

			predicate.And(t => t.LinkedUserId == tutorDTO.LinkedUserId);

			//Expression<Func<Tutor, object>> [] includes = new Expression<Func<Tutor, object>> []
			//	{ t => t.EducationLevels, t => t.Subjects, t => t.TeachingPreferences, t => t.TutorAvailibilities };

			var tutor = await _tutorRepository.GetAsync(predicate);

			if (tutor == null)
			{
				tutor = new Tutor
				{
					Bio = tutorDTO.Bio,
					LinkedUserId = tutorDTO.LinkedUserId,
					PricePerHour = tutorDTO.PricePerHour,
				};

				//List<TutorEducationLevel> tutorEducationLevels = _mapper.Map<List<TutorEducationLevel>>(tutorDTO.TutorEducationLevels);

				//List<TutorSubject> tutorSubjects = _mapper.Map<List<TutorSubject>>(tutorDTO.TutorSubjects);

				//List<TutorTeachingPreference> tutorTeachingPreferences = _mapper.Map<List<TutorTeachingPreference>>(tutorDTO.TutorTeachingPreferences);

				//List<TutorAvailibility> tutorAvailibilities = _mapper.Map<List<TutorAvailibility>>(tutorDTO.TutorAvailibilities);

				//tutorAvailibilities.ForEach(ta => ta.Tutor = tutor);

				//tutor.TutorAvailibilities = tutorAvailibilities;

				await _tutorRepository.AddAsync(tutor);
				//await _tutorEducationLevelRepository.AddRangeAsync(tutorEducationLevels);
				//await _tutorSubjectRepository.AddRangeAsync(tutorSubjects);
				//await _tutorTeachingPreferenceRepository.AddRangeAsync(tutorTeachingPreferences);
			}

			await _tutorRepository.CommitAsync();

			return tutor.Id;
		}
	}
}
