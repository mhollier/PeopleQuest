using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleQuest.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(35)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(35)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime BirthDate { get; set; }

        [MaxLength(50)]
        public string Address1 { get; set; }

        [MaxLength(50)]
        public string Address2 { get; set; }

        [MaxLength(100)]
        public string Interests { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}