namespace School_Backend.Models
{
    public class DisciplineNiveau
    {
        public int Id { get; set; }
        public int DisciplineId {  get; set; }
        public Discipline Discipline { get; set; }
        public int NiveauId { get; set; }
        public Niveau Niveau { get; set; }
    }
}
