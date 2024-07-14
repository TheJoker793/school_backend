﻿namespace School_Backend.DTOs
{
    public class AssiduiteDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public TimeOnly DateDebut { get; set; }
        public TimeOnly DateFin { get; set; }
        public DateTime DateAssiduite { get; set; }
        public string Motif { get; set; }
        public string ConditionTenir { get; set; }
        public int StudentId { get; set; }
    }
}
