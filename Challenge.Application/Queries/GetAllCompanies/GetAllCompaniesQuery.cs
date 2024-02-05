using Challenge.Application.ViewModels;
using MediatR;

namespace Challenge.Application.Queries.GetAllCompanies
{
    public class GetAllCompaniesQuery : IRequest<List<CompanyViewModel>>
    {
    }
}
