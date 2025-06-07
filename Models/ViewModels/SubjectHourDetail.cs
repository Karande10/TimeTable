using System.ComponentModel.DataAnnotations;

namespace TimeTable.Models.ViewModels
{
    public class SubjectHourDetail
    {
        [Required(ErrorMessage = "Subject name is required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [Display(Name = "Subject Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hours required")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be positive")]
        [Display(Name = "Hours")]
        public int Hours { get; set; }
    }
}
