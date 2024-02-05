using System.ComponentModel.DataAnnotations;

namespace Challenge.API.Models
{
    public class AssociateInputModel
    {
        public string Name { get; set; }

        public string Cpf { get; set; }
 
        public DateTime DateBirth { get; set; }
        public List<CompanyInputModel> Companies { get; set; }
    }
}
