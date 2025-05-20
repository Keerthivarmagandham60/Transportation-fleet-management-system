using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering; // For SelectListItem

namespace FleetHub.Models
{
    public class DemoFormViewModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
        [Display(Name = "Full Name")]
        [Key]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email Id is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Id format.")]
        [StringLength(150, ErrorMessage = "Email Id cannot exceed 150 characters.")]
        [Display(Name = "Email Id")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number format.")]
        [StringLength(20, ErrorMessage = "Phone Number cannot exceed 20 characters.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "Country cannot exceed 100 characters.")]
        public string? Country { get; set; } // Nullable, as not required by HTML 'required'

        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
        public string? City { get; set; } // Nullable, as not required by HTML 'required'

        [StringLength(200, ErrorMessage = "Company Name cannot exceed 200 characters.")]
        [Display(Name = "Company Name")]
        public string? CompanyName { get; set; } // Nullable

        [Required(ErrorMessage = "Fleet Size is required.")]
        [Display(Name = "Fleet Size")]
        public string FleetSize { get; set; } // Stores selected value (e.g., "1-10")

        [Required(ErrorMessage = "Product selection is required.")]
        [Display(Name = "Product")]
        public string SelectedProduct { get; set; } // Stores selected value (e.g., "Fleet Management")

        // Properties for dropdown options (used to populate the <select> tags)
        //public List<SelectListItem> FleetSizeOptions { get; set; } = new List<SelectListItem>
        //{
        //    new SelectListItem { Value = "", Text = "Select fleet size", Disabled = true, Selected = true },
        //    new SelectListItem { Value = "1-10", Text = "1-10" },
        //    new SelectListItem { Value = "11-50", Text = "11-50" },
        //    new SelectListItem { Value = "51+", Text = "51+" }
        //};

        //public List<SelectListItem> ProductOptions { get; set; } = new List<SelectListItem>
        //{
        //    new SelectListItem { Value = "", Text = "Select the Product you are looking for", Disabled = true, Selected = true },
        //    new SelectListItem { Value = "Fleet Management", Text = "Fleet Management" },
        //    new SelectListItem { Value = "Route Planning", Text = "Route Planning" }
        //};
   
    }
}