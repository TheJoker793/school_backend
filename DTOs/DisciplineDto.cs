using School_Backend.Models;

namespace School_Backend.DTOs
{
    public class DisciplineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmploiId { get; set; }
        public int MatiereId { get; set; }
    }
}
