using School_Backend.Models;

namespace School_Backend.DTOs
{
    public class EmploiDto
    {
        public int Id { get; set; }
        public TimeOnly HeureDebut { get; set; }
        public TimeOnly HeureFin { get; set; }
        public int SalleId { get; set; }
        public int ProfesseurId { get; set; }
        public int DisciplineId { get; set; }
        public int ClasseId { get; set; }
    }
}
