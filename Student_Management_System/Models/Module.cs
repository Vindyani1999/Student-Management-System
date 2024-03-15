using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Student_Management_System.Models
{
    public class Module
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        public int Credit { get; set; }

        public ObservableCollection<StudentModule> StudentModules { get; set; }

        public Module() { }

    }
}
