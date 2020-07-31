using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class SummaryViewModel
    {
        public int NbTeachers { get; set; }
        public int NbStudents { get; set; }
        public int NbCourses { get; set; }
        public Dictionary<string, decimal> AverageByCourse { get; set; }
    }
}
