using System.Linq.Expressions;

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
	public class UpdateTutorService : IUpdateTutorService
	{
		private readonly IRepository<Tutor> _tutorRepository;
		private readonly ICreateTutorAvailibilityService _createTutorAvailibilityService;
		private readonly ICreateTutorEducationLevelService _createTutorEducationLevel;
		private readonly ICreateTutorSubjectService _createTutorSubjectService;
		private readonly ICreateTutorTeachingPreferenceService _createTutorTeachingPreferenceService;

		public UpdateTutorService(IRepository<Tutor> tutorRepository,
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

		public async Task UpdateTutorAsync(UpdateTutorAngularDTO updateTutorAngularDTO)
		{
			ExpressionStarter<Tutor> predicate = PredicateBuilder.New<Tutor>();

			Expression<Func<Tutor, object>> [] includes = new Expression<Func<Tutor, object>> []
				{ t => t.EducationLevels, t => t.Subjects, t => t.TeachingPreferences, t => t.TutorAvailibilities };

			predicate.And(t => t.LinkedUserId == updateTutorAngularDTO.LinkedUserId);

			var tutor = await _tutorRepository.GetAsync(predicate, includes) ?? throw new Exception("Tutor not found");

			using (var transaction = await _tutorRepository.StartTransactionAsync())
			{
				tutor.Bio = updateTutorAngularDTO.Bio;
				tutor.Introduction = updateTutorAngularDTO.Introduction;
				tutor.PricePerHour = updateTutorAngularDTO.PricePerHour;

				await _tutorRepository.UpdateAsync(tutor);
				await _tutorRepository.CommitAsync();

				updateTutorAngularDTO.TutorAvailibilities = updateTutorAngularDTO.TutorAvailibilities.Distinct().ToList();

				CreateTutorDTO tutorDTO = new()
				{
					TutorAvailibilities = updateTutorAngularDTO.TutorAvailibilities
				};

				tutorDTO.TutorEducationLevels.ToList().AddRange(updateTutorAngularDTO.TutorEducationLevels
					.Select(el => new TutorEducationLevelDTO()
					{
						EducationLevelId = el
					}));

				tutorDTO.TutorTeachingPreferences.ToList().AddRange(updateTutorAngularDTO.TutorTeachingPreferences
					.Select(tp => new TutorTeachingPreferenceDTO()
					{
						TeachingPreferenceId = tp
					}));

				tutorDTO.TutorSubjects.ToList().AddRange(updateTutorAngularDTO.TutorSubjects
					.Select(s => new TutorSubjectDTO()
					{
						SubjectId = s
					}));

				await _createTutorAvailibilityService.CreateTutorAvailibilityAsync(tutor.Id, tutorDTO.TutorAvailibilities);

				await _createTutorEducationLevel.CreateTutorEducationLevelAsync(tutor.Id, tutorDTO.TutorEducationLevels);

				await _createTutorSubjectService.CreateTutorSubjectAsync(tutor.Id, tutorDTO.TutorSubjects);

				await _createTutorTeachingPreferenceService.CreateTutorTeachingPreferenceAsync(tutor.Id, tutorDTO.TutorTeachingPreferences);

				await transaction.CommitAsync();
			}
		}
	}
}
