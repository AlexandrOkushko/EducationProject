using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace CafeDAL.Models
{
    public partial class Employees : EntityBase
    {
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Second Name")]
        public string SecondName { get; set; }

        [Required, Display(Name = "Passport Id")]
        public int PassportId { get; set; }

        [Required]
        public int INN { get; set; }

        [Required, Display(Name = "Birdth Date")]
        public DateTime BirdthDate { get; set; }

        [Required]
        public bool Sex { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
