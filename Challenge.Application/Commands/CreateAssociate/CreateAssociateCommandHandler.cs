using Challenge.Core.Entities;
using Challenge.Core.Repositories;
using MediatR;

namespace Challenge.Application.Commands.CreateAssociate
{
    public class CreateAssociateCommandHandler : IRequestHandler<CreateAssociateCommand, int>
    {
        private readonly IAssociateRepository _associateRepository;
        private readonly ICompanyRepository _companyRepository;

        public CreateAssociateCommandHandler(IAssociateRepository associateRepository, ICompanyRepository companyRepository)
        {
            _associateRepository = associateRepository;
            _companyRepository = companyRepository;
        }

        public async Task<int> Handle(CreateAssociateCommand request, CancellationToken cancellationToken)
        {
            var associate = new Associate(request.Name, request.Cpf, request.DateBirth);

            if(request.CompanyIds != null)
            {
                foreach (var companyId in request.CompanyIds)
                {
                    var company = await _companyRepository.GetByIdAsync(companyId);
                    if (company != null)
                    {
                        associate.Companies.Add(company);
                    }
                    else
                    {
                        await Console.Out.WriteLineAsync("Empresa não existe!");
                        continue;
                    }
                }
            }

            await _associateRepository.AddAsync(associate);

            return associate.Id;
        }
    }
}
