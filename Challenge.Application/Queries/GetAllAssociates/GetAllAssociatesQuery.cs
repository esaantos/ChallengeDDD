using Challenge.Application.ViewModels;
using MediatR;

namespace Challenge.Application.Queries.GetAllAssociates
{
    public class GetAllAssociatesQuery : IRequest<List<AssociateViewModel>>
    {
    }
}
