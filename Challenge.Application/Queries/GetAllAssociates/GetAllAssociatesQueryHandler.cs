using Challenge.Application.ViewModels;
using Challenge.Core.Repositories;
using MediatR;

namespace Challenge.Application.Queries.GetAllAssociates
{
    public class GetAllAssociatesQueryHandler : IRequestHandler<GetAllAssociatesQuery, List<AssociateViewModel>>
    {
        private readonly IAssociateRepository _associateRepository;

        public GetAllAssociatesQueryHandler(IAssociateRepository associateRepository)
        {
            _associateRepository = associateRepository;
        }

        public async Task<List<AssociateViewModel>> Handle(GetAllAssociatesQuery request, CancellationToken cancellationToken)
        {
            var associates = await _associateRepository.GetAllAsync();

            var associatesViewModel = associates
                .Select(a => new AssociateViewModel(a.Id, a.Name, a.Cpf, a.DateBirth))
                .ToList();

            return associatesViewModel;
        }
    }
}
