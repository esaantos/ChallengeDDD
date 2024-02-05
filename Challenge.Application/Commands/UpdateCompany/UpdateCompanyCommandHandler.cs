using Challenge.Core.Repositories;
using MediatR;

namespace Challenge.Application.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IAssociateRepository _associateRepository;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IAssociateRepository associateRepository)
        {
            _companyRepository = companyRepository;
            _associateRepository = associateRepository;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);
            if (company is null)
            {
                throw new InvalidOperationException("Empresa não encontrada.");
            }
            var associate = await _associateRepository.GetByIdAsync(request.AddAssociate);

            company.Update(request.Name, request.Cnpj);
            if(request.AddAssociate != null)
            {
                company.Associates.Add(associate);                
            }
            if(request.RemoveAssociate != null)
            {
                company.Associates.Remove(associate);
            }
            await _companyRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
