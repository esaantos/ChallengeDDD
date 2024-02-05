namespace Challenge.Core.Entities
{
    public class Associate : BaseEntity
    {
        public Associate(string name, string cpf, DateTime dateBirth)
        {
            Name = name;
            Cpf = cpf;
            DateBirth = dateBirth;

            Companies = new List<Company>();
        }

        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime DateBirth { get; set; }
        public virtual List<Company> Companies { get; private set; }


        public void Update(string name, string cpf, DateTime datebirth)
        {
            Name = name;
            Cpf = cpf;
            DateBirth = datebirth;
        }
    }
}
