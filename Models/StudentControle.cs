namespace School_Backend.Models
{
    public class StudentControle
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ControleId  { get; set; }
        public Controle Controle { get; set; }
    }
}
