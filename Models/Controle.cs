namespace School_Backend.Models
{
    public class Controle
    {
        public int Id { get; set; }
        public string Liblle {  get; set; }
        public DateTime DateControle { get; set; }
        public TimeOnly Duree {  get; set; }
        public string Periode { get; set; }
        public ICollection<StudentControle>? StudentControles { get; set; }
    }
}
