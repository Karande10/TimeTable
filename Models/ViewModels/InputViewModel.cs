using System.ComponentModel.DataAnnotations;

namespace TimeTable.Models.ViewModels
{
    public class InputViewModel
    {
        [Required(ErrorMessage = "Number of working days is required")]
        [Range(1, 7, ErrorMessage = "Number of working days is between 1 and 7")]
        [Display(Name = "Working Days")]
        public int NoOfWorkingDays { get; set; }

        [Required(ErrorMessage = "Subjects per day is required")]
        [Range(1, 8, ErrorMessage = "Subjects per day is less than 9")]
        [Display(Name = "Subjects Per Day")]
        public int NoOfSubjectsPerDay { get; set; }

        [Required(ErrorMessage = "Total subjects is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be positive")]
        [Display(Name = "Total Subjects")]
        public int TotalSubjects { get; set; }

        [Display(Name = "Total Weekly Hours")]
        public int TotalHoursForWeek => NoOfWorkingDays * NoOfSubjectsPerDay;
    }
}
