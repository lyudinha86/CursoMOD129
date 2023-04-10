﻿using System.ComponentModel.DataAnnotations;

namespace CursoMOD129.Models
{
    // Code First- Entity Framework -ORM -> OBJECT RELATIONAL MAPP
    public class Cliente
    {
        public int ID { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthday  { get;set; }

        [StringLength(100)]
        [Required]
        public string Address { get; set; }


        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [StringLength(255)]
        [Required]
        public string NIF { get; set; }

        [StringLength(255)]
        public string? HealthCareNumber { get; set; }  
    }
}
