using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.TutorEducationLevels;
using OTP.Dtos.Tutors;
using OTP.Dtos.TutorSubjects;
using OTP.Dtos.TutorTeachingPreferences;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class CreateTutorService : ICreateTutorService
	{
		private readonly IRepository<Tutor> _tutorRepository;
		private readonly ICreateTutorAvailibilityService _createTutorAvailibilityService;
		private readonly ICreateTutorEducationLevelService _createTutorEducationLevel;
		private readonly ICreateTutorSubjectService _createTutorSubjectService;
		private readonly ICreateTutorTeachingPreferenceService _createTutorTeachingPreferenceService;

		public CreateTutorService(IRepository<Tutor> tutorRepository,
			ICreateTutorAvailibilityService createTutorAvailibilityService,
			ICreateTutorEducationLevelService createTutorEducationLevel,
			ICreateTutorSubjectService createTutorSubjectService,
			ICreateTutorTeachingPreferenceService createTutorTeachingPreferenceService)
		{
			_tutorRepository = tutorRepository;
			_createTutorAvailibilityService = createTutorAvailibilityService;
			_createTutorEducationLevel = createTutorEducationLevel;
			_createTutorSubjectService = createTutorSubjectService;
			_createTutorTeachingPreferenceService = createTutorTeachingPreferenceService;
		}

		public async Task<int> CreateTutorAsync(CreateTutorAngularDTO createTutorAngularDTO)
		{
			ExpressionStarter<Tutor> predicate = PredicateBuilder.New<Tutor>();

			CreateTutorDTO tutorDTO = new()
			{
				Bio = createTutorAngularDTO.Bio,
				Introduction = createTutorAngularDTO.Introduction,
				LinkedUserId = createTutorAngularDTO.LinkedUserId,
				PricePerHour = createTutorAngularDTO.PricePerHour,
				TutorAvailibilities = createTutorAngularDTO.TutorAvailibilities
			};

			foreach (var el in createTutorAngularDTO.TutorEducationLevels)
			{
				tutorDTO.TutorEducationLevels.Add(new TutorEducationLevelDTO
				{
					EducationLevelId = el
				});
			}

			//tutorDTO.TutorEducationLevels.ToList().AddRange(createTutorAngularDTO.TutorEducationLevels
			//	.Select(el => new TutorEducationLevelDTO()
			//	{
			//		EducationLevelId = el
			//	}));

			foreach (var tp in createTutorAngularDTO.TutorTeachingPreferences)
			{
				tutorDTO.TutorTeachingPreferences.Add(new TutorTeachingPreferenceDTO
				{
					TeachingPreferenceId = tp
				});
			}

			//tutorDTO.TutorTeachingPreferences.ToList().AddRange(createTutorAngularDTO.TutorTeachingPreferences
			//	.Select(tp => new TutorTeachingPreferenceDTO()
			//	{
			//		TeachingPreferenceId = tp
			//	}));

			foreach (var s in createTutorAngularDTO.TutorSubjects)
			{
				tutorDTO.TutorSubjects.Add(new TutorSubjectDTO
				{
					SubjectId = s
				});
			}

			predicate.And(t => t.LinkedUserId == tutorDTO.LinkedUserId);

			int id = 0;

			using (var transaction = await _tutorRepository.StartTransactionAsync())
			{
				var tutor = await _tutorRepository.GetAsync(predicate);

				if (tutor == null)
				{
					tutor = new Tutor
					{
						Bio = tutorDTO.Bio,
						Introduction = tutorDTO.Introduction,
						LinkedUserId = tutorDTO.LinkedUserId,
						PricePerHour = tutorDTO.PricePerHour,
					};

					await _tutorRepository.AddAsync(tutor);

					await _tutorRepository.CommitAsync();

					await _createTutorAvailibilityService.CreateTutorAvailibilityAsync(tutor.Id, tutorDTO.TutorAvailibilities);

					await _createTutorEducationLevel.CreateTutorEducationLevelAsync(tutor.Id, tutorDTO.TutorEducationLevels);

					await _createTutorSubjectService.CreateTutorSubjectAsync(tutor.Id, tutorDTO.TutorSubjects);

					await _createTutorTeachingPreferenceService.CreateTutorTeachingPreferenceAsync(tutor.Id, tutorDTO.TutorTeachingPreferences);

					await transaction.CommitAsync();

					id = tutor.Id;
				}
				else
				{
					throw new Exception("Tutor already exists.");
				}
			}

			await _tutorRepository.SP("dbo.uspSetTutorDataFromIdentityServerData");

			return id;
		}
	}
}
