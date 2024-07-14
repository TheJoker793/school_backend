using School_Backend.Models;

namespace School_Backend.DTOs
{
    public class ReglementDto
    {
        public int Id { get; set; }
        public float Montant { get; set; }

        public DateTime DateReglement { get; set; }
        public string ModePaiement { get; set; }
        public DateTime DateEcheance { get; set; }
        public string MoisRegler { get; set; }
        public int StudentId { get; set; }
    }
}
