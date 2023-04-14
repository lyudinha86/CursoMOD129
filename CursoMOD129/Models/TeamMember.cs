﻿using System.ComponentModel.DataAnnotations;

namespace CursoMOD129.Models
{
    public class TeamMember
    {

        public int ID { get; set; }

        [Display(Name="Fullname")]
        [StringLength(255)]
        [Required]
        public string Name { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthday { get; set; }

        [StringLength(100)]
        [Required]
        public string Address { get; set; }


        [Display(Name = "Zip Code")]
        [StringLength(20)]
        [Required]
        public string ZipCode { get; set; }



        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [StringLength(255)]
        [Required]
        public string NIF { get; set; }

        [Required]
        public int WorkRoleID { get; set; }

        public WorkRole WorkRole{ get; set; }

       
        public  Specialty? Specialty { get; set; }


    }
}
