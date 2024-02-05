using MediatR;

namespace Challenge.Application.Commands.DeleteAssociate
{
    public class DeleteAssociateCommand : IRequest<Unit>
    {
        public DeleteAssociateCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
