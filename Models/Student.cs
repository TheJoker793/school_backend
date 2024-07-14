using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Backend.Models
{
    public class Student
    {
        [Key]
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
        [ForeignKey("PreviousSchoolId")]
        public PreviousSchool? PreviousSchool { get; set; }
        public ICollection<ParentStudent>? ParentsStudents { get; set; }
        public ICollection<Assiduite>? Assiduites { get; set; }
        public ICollection<AnneeScolaire>? AnneeScolaires { get; set; }
        public ICollection<StudentControle>? StudentControles { get; set; }
        public ICollection<Reglement> Reglements { get; set; }

    }
}
