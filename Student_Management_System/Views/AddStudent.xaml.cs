using Student_Management_System.ViewModels;
using System.Windows;

namespace Student_Management_System.Views
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent(AddStudentViewModele vm)
        {
            InitializeComponent();
            DataContext = vm;
            vm.CloseAction = () => Close();
        }
    }
}
