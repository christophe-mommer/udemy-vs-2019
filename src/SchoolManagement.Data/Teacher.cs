using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public ICollection<Course> TeachedCourses { get; set; }
    }
}
