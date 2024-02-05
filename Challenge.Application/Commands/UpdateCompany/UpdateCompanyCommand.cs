using MediatR;

namespace Challenge.Application.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public int? AddAssociate { get; set; } 
        public int? RemoveAssociate { get; set; }
    }
}
