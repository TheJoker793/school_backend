namespace School_Backend.Models
{
    public class Classe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AnneeScolaire>? AnneeScolaires { get; set; }
        public int NiveauId { get; set; }
        public Niveau Niveau { get; set; }
        public ICollection<Emploi> Emplois { get; set; }


    }
}
