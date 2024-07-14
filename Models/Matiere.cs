namespace School_Backend.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Discipline> Disciplines { get; set; }
    }
}
