using Challenge.Core.Repositories;
using MediatR;

namespace Challenge.Application.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Unit>
    {
        public readonly ICompanyRepository _companyRepository;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);
            if (company is null)
            {
                throw new InvalidOperationException("Empresa não encontrada.");
            }
            await _companyRepository.RemoveAsync(company);

            return Unit.Value;
        }
    }
}
