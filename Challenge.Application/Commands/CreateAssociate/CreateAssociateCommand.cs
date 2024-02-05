using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Application.Commands.CreateAssociate
{
    public class CreateAssociateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateBirth { get; set; }
        public List<int>? CompanyIds { get; set; }
    }
}
