using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFMS.Models
{
    [Table("Fuels")]
    public class Fuel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FuelId { get; set; }

        [Required]
        public int VehicleId { get; set; }  // Foreign Key

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")] // Specify the data type for SQL Server
        public decimal FuelQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cost { get; set; }

        // Navigation Property (Optional)
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
    }
}
