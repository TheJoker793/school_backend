using School_Backend.Models;

namespace School_Backend.DTOs
{
    public class NiveauDto
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Option { get; set; }
        public int Capacite { get; set; }
        
    }
}
