namespace School_Backend.Models
{
    public class Reglement
    {
        public int Id { get; set; }
        public float Montant { get; set; }
        public DateTime DateReglement { get; set; }
        public string ModePaiement { get; set;}
        public DateTime DateEcheance { get; set;}
        public string MoisRegler { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public ICollection<Frais> Fraiss { get; set; }
    }
}
