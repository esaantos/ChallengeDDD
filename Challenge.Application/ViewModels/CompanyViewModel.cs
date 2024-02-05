using Challenge.Core.Entities;

namespace Challenge.Application.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel(int id, string name, string cnpj)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
    }
}
