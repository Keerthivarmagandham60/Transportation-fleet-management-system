using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFMS.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        public int Capacity { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? LastServicedDate { get; set; }
    }
}
