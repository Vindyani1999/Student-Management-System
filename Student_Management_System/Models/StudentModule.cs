using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Student_Management_System.Models
{
    public class StudentModule
    {
        public string StudentReg { get; set; }

        public Student Student { get; set; }

        public string ModuleCode { get; set; }

        public Module Module { get; set; }

        public string Grade { get; set; }

        public double Marks { get; set; }

        public StudentModule() { }
    }
}
