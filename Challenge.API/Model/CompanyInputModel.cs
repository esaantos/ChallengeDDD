using System.ComponentModel.DataAnnotations;

namespace Challenge.API.Models
{
    public class CompanyInputModel
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public List<AssociateInputModel> Associates { get; set; }
    }
}
