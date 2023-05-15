﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CursoMOD129.Models
{
    public class Appointment
    {

        public int ID { get; set; }

        [Display(Name = "Appointment Number")]
        [Required]
        public string Number { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [Required]
        public DateTime Time { get; set; }


        [Required]
        [Display(Name = "Cliente")]

        public int ClienteID { get; set; }


        [ValidateNever]
        public Cliente Cliente { get; set;}

        [Required]
        [Display(Name ="Medic")]
        public int MedicID { get; set; 
        }
        [ValidateNever]
        public TeamMember Medic { get; set; }
        public string Info { get; set; }
        [Display(Name ="Done")]
        public bool IsDone { get; set; }
    }
}
