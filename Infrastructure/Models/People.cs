using Infrastructure.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class People
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PassportSerialNumber { get; set; }
    }
}
