namespace TimeTable.Models.ViewModels
{
    public class SubjectHoursInputViewModel
    {
        public int NoOfWorkingDays { get; set; }
        public int NoOfSubjectsPerDay { get; set; }
        public int TotalSubjects { get; set; }
        public int TotalHoursForWeek { get; set; }
        public List<SubjectHourDetail> SubjectHours { get; set; } = new List<SubjectHourDetail>();
    }
}
