namespace School_Backend.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Place { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public int PreviousSchoolId { get; set; }
    }
}
