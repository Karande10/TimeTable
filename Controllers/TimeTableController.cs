using Microsoft.AspNetCore.Mvc;
using TimeTable.Models.ViewModels;
using TimeTable.Services.Interface;

namespace TimeTable.Controllers
{
    public class TimeTableController : Controller
    {
        private readonly ITimeTableService _timeTableService;

        public TimeTableController(ITimeTableService timeTableService)
        {
            _timeTableService = timeTableService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new InputViewModel());
        }

        [HttpPost]
        public IActionResult ProcessInitialInput(InputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var subjectHoursModel = new SubjectHoursInputViewModel
            {
                NoOfWorkingDays = model.NoOfWorkingDays,
                NoOfSubjectsPerDay = model.NoOfSubjectsPerDay,
                TotalSubjects = model.TotalSubjects,
                TotalHoursForWeek = model.TotalHoursForWeek
            };

            for (int i = 0; i < model.TotalSubjects; i++)
            {
                subjectHoursModel.SubjectHours.Add(new SubjectHourDetail());
            }

            return View("EnterSubjectHours", subjectHoursModel);
        }

        [HttpPost]
        public IActionResult GenerateTimeTable(SubjectHoursInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("EnterSubjectHours", model);
            }

            var totalEnteredHours = model.SubjectHours.Sum(s => s.Hours);
            if (totalEnteredHours != model.TotalHoursForWeek)
            {
                ModelState.AddModelError("", $"Total subject hours ({totalEnteredHours}) must equal weekly hours ({model.TotalHoursForWeek})");
                return View("EnterSubjectHours", model);
            }

            var timeTable = _timeTableService.GenerateTimeTable(model);
            return View("DisplayTimeTable", timeTable);
        }
    }
}
