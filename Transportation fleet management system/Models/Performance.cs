using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFMS.Models
{
    public class Performance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerformanceId { get; set; }

        [Required]
        [StringLength(50)]
        public string ReportType { get; set; }

        [Required]
        public string Data { get; set; } //  Consider using a more specific type if possible (e.g., JSON string, or a related entity)

        [Required]
        public DateTime GeneratedOn { get; set; }
    }
}
