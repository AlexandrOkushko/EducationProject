using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeDAL.Models
{
    [Table("Employees")]
    public partial class Employees : EntityBase
    {
        [Required, Display(Name = "First Name"), StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name"), StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required, Display(Name = "Passport Id")]
        public int PassportId { get; set; }

        [Required]
        public int INN { get; set; }

        [Required, Display(Name = "Birdth Date")]
        public DateTime BirdthDate { get; set; }

        public int GenderId { get; set; }

        [Required, Phone, StringLength(30, MinimumLength = 3)]
        public string Phone { get; set; }

        public int RoleId { get; set; }

        [Required, EmailAddress, StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), StringLength(30, MinimumLength = 3)]
        public string Password { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Roles Roles { get; set; }

        [ForeignKey(nameof(GenderId))]
        public Gender Gender { get; set; }
    }
}
