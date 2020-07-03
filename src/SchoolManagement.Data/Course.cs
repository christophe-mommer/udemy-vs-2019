using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public Teacher TeachedBy { get; set; }
        public int TeacherId { get; set; }
        public ICollection<CourseParticipation> Participations { get; set; }
    }
}
