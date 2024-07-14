using School_Backend.Models;

namespace School_Backend.DTOs
{
    public class FraisDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Frais1 { get; set; }
        public double Frais2 { get; set; }
        public double Frais3 { get; set; }
        public int ReglementId { get; set; }
        public int NiveauId { get; set; }
    }
}
