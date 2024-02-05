using Challenge.Application.ViewModels;
using MediatR;

namespace Challenge.Application.Queries.GetCompanyById
{
    public class GetCompanyByIdQuery : IRequest<CompanyViewModel>
    {
        public GetCompanyByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
