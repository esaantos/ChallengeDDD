namespace Challenge.Application.ViewModels
{
    public class AssociateViewModel
    {
        public AssociateViewModel(int id, string name, string cpf, DateTime dateBirth)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            DateBirth = dateBirth;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
