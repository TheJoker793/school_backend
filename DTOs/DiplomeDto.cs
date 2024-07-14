namespace School_Backend.DTOs
{
    public class DiplomeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Niveau { get; set; }
        public string Ecole { get; set; }
        public DateTime DateObtenir { get; set; }
        public int ProfesseurId { get; set; }
    }
}
