using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolManagement.Data;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchoolManagementContext context;

        public HomeController(ILogger<HomeController> logger,
            SchoolManagementContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            Debugger.Launch();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Summary()
        {
            var result = new SummaryViewModel();

            var coursesNb = Task.Run(() => context.Courses.Count());
            var teachersNb = Task.Run(() => context.Teachers.Count());
            var studentsNb = Task.Run(() => context.Students.Count());

            var computeAverage = Task.Run(async () =>
            {
                var concurrentDic = new ConcurrentDictionary<string, List<decimal>>();
                foreach (var item in await context.Students.SelectMany(s => s.Courses).Include(c => c.Course).ToListAsync())
                {
                    concurrentDic.AddOrUpdate(item.Course.Name, new List<decimal> { item.Notation }, (_, l) => { l.Add(item.Notation); return l; });
                }
                return concurrentDic;
            });

            result.NbCourses = await coursesNb;
            result.NbTeachers = await teachersNb;
            result.NbStudents = await studentsNb;
            result.AverageByCourse = (await computeAverage).ToDictionary(c => c.Key, c => c.Value.Average());
            return View(result);
        }

    }
}
