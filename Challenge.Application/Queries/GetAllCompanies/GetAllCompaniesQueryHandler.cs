using Challenge.Application.ViewModels;
using Challenge.Core.Repositories;
using MediatR;

namespace Challenge.Application.Queries.GetAllCompanies
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyViewModel>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyViewModel>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllAsync();

            var companyViewModel = companies
                .Select(c => new CompanyViewModel(c.Id, c.Name, c.Cnpj))
                .ToList();

            return companyViewModel;
        }
    }
}
