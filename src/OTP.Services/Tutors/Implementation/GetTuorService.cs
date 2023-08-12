using System.Linq.Expressions;

using AutoMapper;

using LinqKit;

using OTP.Domains.Models.Tutors;
using OTP.Dtos.Tutors;
using OTP.Repositories.Interfaces;
using OTP.Services.Tutors.Interfaces;

namespace OTP.Services.Tutors.Implementation
{
	public class GetTuorService : IGetTuorService
	{
		private readonly IRepository<Tutor> _tutorRepository;
		private readonly IMapper _mapper;

		public GetTuorService(IRepository<Tutor> tutorRepository, IMapper mapper)
		{
			_tutorRepository = tutorRepository;
			_mapper = mapper;
		}

		public async Task<GetTutorDTO> GetTutorByIdAsync(int tutorId)
		{
			ExpressionStarter<Tutor> predicate = PredicateBuilder.New<Tutor>();

			predicate.And(t => t.Id == tutorId);

			Expression<Func<Tutor, object>> [] includes = new Expression<Func<Tutor, object>> []
				{ t => t.EducationLevels, t => t.Subjects, t => t.TeachingPreferences, t => t.TutorAvailibilities };

			var tutor = await _tutorRepository.GetAsync(predicate);

			var getTutorDTO = _mapper.Map<GetTutorDTO>(tutor);

			return getTutorDTO;
		}
	}
}
