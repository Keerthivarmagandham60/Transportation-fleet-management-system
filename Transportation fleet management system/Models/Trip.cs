using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFMS.Models
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TripId { get; set; }

        [Required]
        public int VehicleId { get; set; }  // Foreign Key

        public int? DriverId { get; set; }    // Foreign Key (Nullable)

        [Required]
        [StringLength(100)]
        public string StartLocation { get; set; }

        [Required]
        [StringLength(100)]
        public string EndLocation { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        // Navigation Properties (Optional, for easier data access)
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        [ForeignKey("DriverId")]  // Add this if you have a Driver table
        public Driver Driver { get; set; } // ADD THIS LINE HERE

    }
}
