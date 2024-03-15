using Student_Management_System.ViewModels;
using System.Windows;


namespace Student_Management_System.Views
{
    /// <summary>
    /// Interaction logic for AddModule.xaml
    /// </summary>
    public partial class AddModule : Window
    {
        public AddModule(AddModuleViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
