namespace School_Backend.Models
{
    public class Frais
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Frais1 { get; set; }
        public double Frais2 { get; set; }
        public double Frais3 { get; set; }
        public int ReglementId { get; set; }
        public Reglement Reglement { get; set; }
        public int NiveauId { get; set; }
        public Niveau Niveau { get; set; }
    }
}
