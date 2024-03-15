using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Student_Management_System.Models
{
    public class Student
    {
        [Key]
        public string RegNo { get; set; }

        public string FirstName {get; set;}

        public string LastName {get; set;}

        public string Address { get; set; }

        public int TelephoneNo { get; set; }

        public double Gpa { get; set; }

        public ObservableCollection<StudentModule> StudentModules { get; set; }

        public Student() { }
    }

    
}
