using System.ComponentModel.DataAnnotations;

namespace School_Backend.Models
{
    public class AnneeScolaire
    {
        
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int StudentId {  get; set; }
        public Student Student { get; set; }    
        public int ClasseId { get; set; }
        public Classe Classe { get; set; }


    }
}
