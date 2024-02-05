using Challenge.Core.Repositories;
using MediatR;

namespace Challenge.Application.Commands.UpdateAssociate
{
    public class UpdateAssociateCommandHandler : IRequestHandler<UpdateAssociateCommand, Unit>
    {
        private readonly IAssociateRepository _associateRepository;
        private readonly ICompanyRepository _companyRepository;

        public UpdateAssociateCommandHandler(IAssociateRepository associateRepository, ICompanyRepository companyRepository)
        {
            _associateRepository = associateRepository;
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(UpdateAssociateCommand request, CancellationToken cancellationToken)
        {
            var associate = await _associateRepository.GetByIdAsync(request.Id);

            if(associate is null)
            {
                throw new InvalidOperationException("Associado não encontrado.");
            }

            associate.Update(request.Name, request.Cpf, request.DateBirth);

            if(request.AddCompany != null)
            {
                var company = await _companyRepository.GetByIdAsync(request.AddCompany);
                if (company != null)
                    associate.Companies.Add(company);               
            }

            if(request.RemoveCompany != null)
            {
                var company = await _companyRepository.GetByIdAsync(request.RemoveCompany);
                if (company != null)
                    associate.Companies.Remove(company); 
            }

            await _associateRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
