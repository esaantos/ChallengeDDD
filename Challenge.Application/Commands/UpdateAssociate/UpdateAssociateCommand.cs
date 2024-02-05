using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Application.Commands.UpdateAssociate
{
    public class UpdateAssociateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateBirth { get; set; }
        public int? AddCompany { get; set; }
        public int? RemoveCompany { get; set; }
    }
}
