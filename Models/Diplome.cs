namespace School_Backend.Models
{
    public class Diplome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Niveau { get; set; }
        public string Ecole { get; set; }
        public DateTime DateObtenir { get; set; }
        public int ProfesseurId { get; set; }
        public Professeur Professeur { get; set; }
    }
}
