using Challenge.Core.Entities;
using Challenge.Core.Repositories;
using MediatR;

namespace Challenge.Application.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IAssociateRepository _associateRepository;
        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IAssociateRepository associateRepository)
        {
            _companyRepository = companyRepository;
            _associateRepository = associateRepository;
        }

        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company(request.Name, request.Cnpj);

            if(request.AssociateId != null)
            {
                foreach (var associateId in request.AssociateId)
                {
                    var associate = await _associateRepository.GetByIdAsync(associateId);
                    if(associate != null)
                    {
                        company.Associates.Add(associate);
                    }
                    else
                        continue;                    
                }
            }

            await _companyRepository.AddAsync(company);

            return company.Id;
        }
    }
}
