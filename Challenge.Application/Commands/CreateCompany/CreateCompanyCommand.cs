using MediatR;

namespace Challenge.Application.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public List<int>? AssociateId { get; set; }
    }
}
