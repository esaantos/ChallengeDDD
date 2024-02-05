using Challenge.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Challenge.Application.Commands.DeleteAssociate
{
    public class DeleteAssociateCommandHandler : IRequestHandler<DeleteAssociateCommand, Unit>
    {
        private readonly IAssociateRepository _associateRepository;

        public DeleteAssociateCommandHandler(IAssociateRepository associateRepository)
        {
            _associateRepository = associateRepository;
        }

        public async Task<Unit> Handle(DeleteAssociateCommand request, CancellationToken cancellationToken)
        {
            var associate = await _associateRepository.GetByIdAsync(request.Id);       
            if(associate is null)
            {
                throw new InvalidOperationException("Associado não encontrado.");
            }
            await _associateRepository.RemoveAsync(associate);

            return Unit.Value;
        }
    }
}
