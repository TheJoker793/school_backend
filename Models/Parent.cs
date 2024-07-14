using System.ComponentModel.DataAnnotations;

namespace School_Backend.Models
{
    public class Parent
    {
        [Key]
        public int Id { get; set; }
        public string Cin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DatOfBirth { get; set; }
        public string TypeParently { get; set; }
        public string Place { get; set; }
        public string Function { get; set; }
        public string Mobile { get; set; }
        public ICollection<ParentStudent>? ParentsStudents { get; set; }

    }
}
