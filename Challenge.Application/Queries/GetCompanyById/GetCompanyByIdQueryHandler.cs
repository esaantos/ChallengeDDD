using Challenge.Application.ViewModels;
using Challenge.Core.Repositories;
using MediatR;

namespace Challenge.Application.Queries.GetCompanyById
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyViewModel>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyByIdQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyViewModel?> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);

            if (company == null) return null;

            var companyViewModel = new CompanyViewModel(company.Id, company.Name, company.Cnpj);

            return companyViewModel;
        }
    }
}
