namespace School_Backend.Models
{
    public class Niveau
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Option { get; set; }
        public int Capacite { get; set; }
        public ICollection<Classe>Classes { get; set; }
        public ICollection<DisciplineNiveau> DisciplineNiveaux { get; set; }
        public ICollection<Frais> Fraiss { get; set; }



    }
}
