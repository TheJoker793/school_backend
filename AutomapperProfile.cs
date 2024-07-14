using AutoMapper;
using School_Backend.DTOs;
using School_Backend.Models;

namespace School_Backend
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PreviousSchool,PreviosSchoolDto>().ReverseMap();
            CreateMap<Student,StudentDto>().ReverseMap();
            CreateMap<Parent,ParentDto>().ReverseMap();
            CreateMap<ParentStudent,ParentStudentDto>().ReverseMap();
            CreateMap<Assiduite,AssiduiteDto>().ReverseMap();
            CreateMap<AnneeScolaire,AnneeScolaireDto>().ReverseMap();
            CreateMap<Classe,ClasseDto>().ReverseMap();
            CreateMap<Niveau,NiveauDto>().ReverseMap();
            CreateMap<Matiere,MatiereDto>().ReverseMap();
            CreateMap<Discipline,DisciplineDto>().ReverseMap();
            CreateMap<DisciplineNiveau, DisciplineNiveauDto>().ReverseMap();
            CreateMap<Controle, ControleDto>().ReverseMap();
            CreateMap<StudentControle,ControleStudentDto>().ReverseMap();
            CreateMap<Professeur,ProfesseurDto>().ReverseMap();
            CreateMap<Salle,SalleDto>().ReverseMap();
            CreateMap<Emploi, EmploiDto>().ReverseMap();
            CreateMap<Diplome, DiplomeDto>().ReverseMap();
            CreateMap<Reglement, ReglementDto>().ReverseMap();
            CreateMap<Frais, FraisDto>().ReverseMap();
        }
    }
}
