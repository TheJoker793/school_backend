namespace School_Backend.Models
{
    public class PreviousSchool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public ICollection<Student>? Students { get; set; }  
    }
}
