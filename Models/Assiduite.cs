namespace School_Backend.Models
{
    public class Assiduite
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public TimeOnly DateDebut { get; set; }
        public TimeOnly DateFin { get; set; }
        public DateTime DateAssiduite {  get; set; }
        public string Motif {  get; set; }
        public string ConditionTenir { get; set; }
        public int StudentId { get; set;}
        public Student Student { get; set; }
        
    }
}
