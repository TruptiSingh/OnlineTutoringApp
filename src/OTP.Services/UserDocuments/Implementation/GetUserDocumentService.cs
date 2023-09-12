using AutoMapper;

using LinqKit;

using OTP.Domains.Models.Common;
using OTP.Dtos.UserDocuments;
using OTP.Repositories.Interfaces;
using OTP.Services.UserDocuments.Interfaces;

namespace OTP.Services.UserDocuments.Implementation
{
	public class GetUserDocumentService : IGetUserDocumentService
	{
		private readonly IRepository<UserDocument> _repository;
		private readonly IMapper _mapper;

		public GetUserDocumentService(IRepository<UserDocument> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<ICollection<GetUserDocumentsDTO>> GetUserDocumentsAsync(int userId)
		{
			var predicate = PredicateBuilder.New<UserDocument>();

			predicate.And(ud => ud.UserId == userId);

			var userDocuments = await _repository.GetAllAsync(predicate);

			var getUserDocumentsDTOs = _mapper.Map<IEnumerable<GetUserDocumentsDTO>>(userDocuments);

			return getUserDocumentsDTOs.ToList();
		}
	}
}
