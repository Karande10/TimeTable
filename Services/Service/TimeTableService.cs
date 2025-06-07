using TimeTable.Models.ViewModels;
using TimeTable.Services.Interface;

namespace TimeTable.Services.Service
{
    public class TimeTableService : ITimeTableService
    {

        //Generate Timetable method
        public List<List<string>> GenerateTimeTable(SubjectHoursInputViewModel model)
        {
            var subjectDistribution = CreateSubjectDistribution(model.SubjectHours);

            var timeTable = InitializeTimeTable(model.NoOfSubjectsPerDay, model.NoOfWorkingDays);

            FillTimeTable(timeTable, subjectDistribution);

            return timeTable;
        }

        //Subject Distrubution method
        private List<string> CreateSubjectDistribution(List<SubjectHourDetail> subjectHours)
        {
            var distribution = new List<string>();

            foreach (var subject in subjectHours.OrderByDescending(s => s.Hours))
            {
                distribution.AddRange(Enumerable.Repeat(subject.Name, subject.Hours));
            }

            var rng = new Random();
            return distribution.OrderBy(x => rng.Next()).ToList();
        }

        //Timetable Initialize method
        private List<List<string>> InitializeTimeTable(int rows, int columns)
        {
            var timeTable = new List<List<string>>();

            for (int i = 0; i < rows; i++)
            {
                timeTable.Add(new List<string>());
                for (int j = 0; j < columns; j++)
                {
                    timeTable[i].Add("Free");
                }
            }

            return timeTable;
        }

        //Fill Timetable method
        private void FillTimeTable(List<List<string>> timeTable, List<string> subjects)
        {
            int subjectIndex = 0;
            int maxAttempts = timeTable.Count * timeTable[0].Count * 2;
            int attempts = 0;

            while (subjectIndex < subjects.Count && attempts < maxAttempts)
            {
                for (int row = 0; row < timeTable.Count && subjectIndex < subjects.Count; row++)
                {
                    for (int col = 0; col < timeTable[row].Count && subjectIndex < subjects.Count; col++)
                    {
                        if (timeTable[row][col] == "Free")
                        {
                            timeTable[row][col] = subjects[subjectIndex];
                            subjectIndex++;
                        }
                    }
                }
                attempts++;
            }
        }
    }
}
