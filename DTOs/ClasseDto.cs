using School_Backend.Models;

namespace School_Backend.DTOs
{
    public class ClasseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NiveauId { get; set; }
        public int EmploiId { get; set; }
        
    }
}
