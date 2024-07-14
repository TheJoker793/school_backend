using School_Backend.Models;

namespace School_Backend.DTOs
{
    public class AnneeScolaireDto
    {
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int StudentId { get; set; }
        public int ClasseId { get; set; }
    }
}
