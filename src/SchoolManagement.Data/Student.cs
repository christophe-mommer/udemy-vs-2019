using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolManagement.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<CourseParticipation> Courses { get; set; }
    }
}
