namespace School_Backend.Models
{
    public class Salle
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Capacite { get; set; }
        public ICollection<Emploi> Emplois { get; set; }

    }
}
