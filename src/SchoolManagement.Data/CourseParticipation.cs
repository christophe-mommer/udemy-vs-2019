using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data
{
    public class CourseParticipation
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public int Notation { get; set; }
    }
}
