namespace School_Backend.DTOs
{
    public class ControleDto
    {
        public int Id { get; set; }
        public string Liblle { get; set; }
        public DateTime DateControle { get; set; }
        public TimeOnly Duree { get; set; }
        public string Periode { get; set; }
    }
}
