namespace School_Backend.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int MatiereId { get; set; }
        public Matiere Matiere { get; set; }
        public ICollection<Emploi> Emplois { get; set; }

        public ICollection<DisciplineNiveau> DisciplineNiveaux { get; set; }
    }
}
