


using Challenge.Core.Repositories;

namespace Challenge.Core.Entities
{
    public class Company : BaseEntity
    {
        public Company(string name, string cnpj)
        {
            Name = name;
            Cnpj = cnpj;

            Associates = new List<Associate>();
        }

        public string Name { get; set; }
        public string Cnpj { get; set; }
        public virtual List<Associate> Associates { get; private set; }
        public void Update(string name, string cnpj)
        {
            Name = name;
            Cnpj = cnpj;
        }
    }
}
