using TimeTable.Models.ViewModels;

namespace TimeTable.Services.Interface
{
    public interface ITimeTableService
    {
        List<List<string>> GenerateTimeTable(SubjectHoursInputViewModel model);

    }
}
