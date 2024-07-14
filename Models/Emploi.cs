namespace School_Backend.Models
{
    public class Emploi
    {
        public int Id { get; set; }
        public TimeOnly HeureDebut { get; set; }
        public TimeOnly HeureFin { get; set; } 
        public int SalleId { get; set; }
        public Salle Salle { get; set; }
        public int ProfesseurId { get; set; }
        public Professeur Professeur { get; set; }
        public int DiSciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public int ClasseId {  get; set; }
        public Classe Classe { get; set; }

    }
}
