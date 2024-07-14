namespace School_Backend.Models
{
    public class Professeur
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Place { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public ICollection<Emploi> Emplois { get; set; }
        public ICollection<Diplome> Diplomes { get; set; }

    }
}
