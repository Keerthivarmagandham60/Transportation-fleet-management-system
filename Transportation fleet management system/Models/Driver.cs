using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFMS.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LicenseNumber { get; set; }

        [MaxLength(20)]
        public string ContactNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
    }
}
  