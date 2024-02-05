using MediatR;

namespace Challenge.Application.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<Unit>
    {
        public DeleteCompanyCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
