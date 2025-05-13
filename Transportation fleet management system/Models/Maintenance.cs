using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFMS.Models
{
    public class Maintenance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaintenanceId { get; set; }

        [Required]
        public int VehicleId { get; set; }  // Foreign Key

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        // Navigation Property (Optional)
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
    }
}

