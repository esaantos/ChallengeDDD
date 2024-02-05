using Challenge.Application.ViewModels;
using MediatR;

namespace Challenge.Application.Queries.GetAssociateById
{
    public class GetAssociateByIdQuery : IRequest<AssociateViewModel>
    {
        public GetAssociateByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
