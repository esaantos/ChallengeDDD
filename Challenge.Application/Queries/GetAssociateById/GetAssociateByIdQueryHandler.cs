using Challenge.Application.ViewModels;
using Challenge.Core.Repositories;
using MediatR;

namespace Challenge.Application.Queries.GetAssociateById
{
    public class GetAssociateByIdQueryHandler : IRequestHandler<GetAssociateByIdQuery, AssociateViewModel>
    {
        private readonly IAssociateRepository _associateRepository;

        public GetAssociateByIdQueryHandler(IAssociateRepository associateRepository)
        {
            _associateRepository = associateRepository;
        }

        public async Task<AssociateViewModel> Handle(GetAssociateByIdQuery request, CancellationToken cancellationToken)
        {
            var associate = await _associateRepository.GetByIdAsync(request.Id);

            return new AssociateViewModel(associate.Id, associate.Name, associate.Cpf, associate.DateBirth);
        }


    }
}
