using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Backend.Models
{
    public class SchoolDbContext(DbContextOptions<SchoolDbContext> options) :DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<PreviousSchool> PreviousSchools { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentStudent> ParentsStudents { get; set; }
        public DbSet<Assiduite> Assiduites { get; set; }
        public DbSet<AnneeScolaire> AnneeScolaires { get; set; }
        public DbSet<Emploi> Emplois { get; set; }
        public DbSet<Classe> Classes {  get; set; }
        public DbSet <Niveau> Niveaux { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<DisciplineNiveau> DisciplineNiveaux { get; set; }
        public DbSet<Professeur> Professeurs {  get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Controle> Controles { get; set; }
        public DbSet<StudentControle> StudentControles { get; set; }
        public DbSet<Diplome> Diplomes { get; set; }
        public DbSet<Frais> Fraiss { get;set;}
        public DbSet<Reglement> Reglements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(p => p.PreviousSchool)
                .WithMany(s => s.Students)
                .HasForeignKey(p => p.PreviousSchoolId);

            modelBuilder.Entity<ParentStudent>()
                .HasKey(ps => new { ps.ParentId,ps.StudentId });


            modelBuilder.Entity<ParentStudent>()
                .HasOne(ps => ps.Student)
                .WithMany(s => s.ParentsStudents)
                .HasForeignKey(ps=>ps.StudentId);
            modelBuilder.Entity<ParentStudent>()
                .HasOne(ps => ps.Parent)
                .WithMany(p => p.ParentsStudents)
                .HasForeignKey(ps => ps.ParentId);

           
            modelBuilder.Entity<AnneeScolaire>()
                .HasOne(c => c.Classe)
                .WithMany(a => a.AnneeScolaires)
                .HasForeignKey(c => c.ClasseId);

            modelBuilder.Entity<AnneeScolaire>()
                .HasOne(s => s.Student)
                .WithMany(a => a.AnneeScolaires)
                .HasForeignKey(s => s.StudentId);


            modelBuilder.Entity<Assiduite>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Assiduites)
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Classe>()
                .HasOne(n => n.Niveau)
                .WithMany(c => c.Classes)
                .HasForeignKey(c => c.NiveauId);

           
            modelBuilder.Entity<Discipline>()
                .HasOne(m => m.Matiere)
                .WithMany(d => d.Disciplines)
                .HasForeignKey(m => m.MatiereId);
            modelBuilder.Entity<DisciplineNiveau>()
                .HasOne(n => n.Niveau)
                .WithMany(dn => dn.DisciplineNiveaux)
                .HasForeignKey(n => n.NiveauId);
            modelBuilder.Entity<DisciplineNiveau>()
                .HasOne(d => d.Discipline)
                .WithMany(dn => dn.DisciplineNiveaux)
                .HasForeignKey(d => d.DisciplineId);
            modelBuilder.Entity<StudentControle>()
                .HasOne(s => s.Student)
                .WithMany(sc =>sc.StudentControles)
                .HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<StudentControle>()
                .HasOne(c => c.Controle)
                .WithMany(sc =>sc.StudentControles)
                .HasForeignKey(c => c.ControleId);
            modelBuilder.Entity<AnneeScolaire>()
                .HasOne(e => e.Student)
                .WithMany(a => a.AnneeScolaires)
                .HasForeignKey(e => e.StudentId);
            modelBuilder.Entity<AnneeScolaire>()
                .HasOne(c=>c.Classe)
                .WithMany(a=>a.AnneeScolaires)
                .HasForeignKey(c=>c.ClasseId);
            modelBuilder.Entity<Diplome>()
                .HasOne(p => p.Professeur)
                .WithMany(d => d.Diplomes)
                .HasForeignKey(p=>p.ProfesseurId);

            modelBuilder.Entity<Reglement>()
                .HasOne(e => e.Student)
                .WithMany(r => r.Reglements)
                .HasForeignKey(e => e.StudentId);
            modelBuilder.Entity<Frais>()
                .HasOne(n =>n.Niveau )
                .WithMany(f => f.Fraiss)
                .HasForeignKey(n => n.NiveauId);
            modelBuilder.Entity<Frais>()
                .HasOne(r => r.Reglement)
                .WithMany(f => f.Fraiss)
                .HasForeignKey(r => r.ReglementId);
           

        }



    }
}
