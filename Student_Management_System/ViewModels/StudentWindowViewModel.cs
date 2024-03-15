using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Student_Management_System.Models;
using Student_Management_System.Views;
using Student_Management_System.DataBase;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;


namespace Student_Management_System.ViewModels
{
    public partial class StudentWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> listofStudent;

        [ObservableProperty]
        public Student selectedStudent;

        DataBaseContext studentData;

        public StudentWindowViewModel()
        {
            studentData = new DataBaseContext();
            LoadStudent();
        }

        private void LoadStudent()
        {
            ListofStudent = new ObservableCollection<Student>(studentData.Students.ToList());
        }

        [RelayCommand]
        public void AddStudent()
        {
            var addstudentvm = new AddStudentViewModele
            {
                Title = "ADD STUDENT"
            };

            AddStudent addStudentVindow = new AddStudent(addstudentvm);
            addStudentVindow.ShowDialog();

            if (addstudentvm.currentStudent != null)
            {
                studentData.Students.Add(addstudentvm.currentStudent);
                studentData.SaveChanges();
                ListofStudent.Add(addstudentvm.currentStudent);
            }
            else
                return;

        }

        [RelayCommand]
        public void EditStudent()
        {
            if (SelectedStudent != null)
            {
                var vm = new AddStudentViewModele(SelectedStudent);
                vm.Title = "EDIT STUDENT";
                var window = new AddStudent(vm);

                window.ShowDialog();

                if (vm.IsSaved)
                {
                    var studentToUpdate = studentData.Students.FirstOrDefault(u => u.RegNo == SelectedStudent.RegNo);
                    if (studentToUpdate != null)
                    {
                        studentToUpdate.RegNo = vm.currentStudent.RegNo;
                        studentToUpdate.FirstName = vm.currentStudent.FirstName;
                        studentToUpdate.LastName = vm.currentStudent.LastName;
                        studentToUpdate.Address = vm.currentStudent.Address;
                        studentToUpdate.TelephoneNo = vm.currentStudent.TelephoneNo;

                        studentData.SaveChanges();
                        int index = ListofStudent.IndexOf(SelectedStudent);
                        ListofStudent.RemoveAt(index);
                        ListofStudent.Insert(index, studentToUpdate);
                    }
                }
            }
            else
                MessageBox.Show("Please Select Student");
        }

        [RelayCommand]
        public void Delete()
        {
            if (SelectedStudent != null)
            {
                studentData.Remove(SelectedStudent);
                studentData.SaveChanges();
                MessageBox.Show("Student Sucessfuly Delete");
                ListofStudent.Remove(SelectedStudent);
            }

            else
                MessageBox.Show("Please Select Student");
        }

        [RelayCommand]
        public void AddModule()
        {
            if (SelectedStudent != null)
            {
                var vm = new AddModuleViewModel(SelectedStudent);
                var window = new AddModule(vm);
                window.ShowDialog();
            }
            else
                MessageBox.Show("Please Select Student");
        }

        [RelayCommand]
        public void AddGrade()
        { 
            if (SelectedStudent != null)
            {
                var vm = new AddGradeViewModel(SelectedStudent);
                var window = new AddGrade(vm);
                window.ShowDialog();
            }
            else
                MessageBox.Show("Please Select Student");
        }

        [RelayCommand]
        public void ShowResult()
        {
            if (SelectedStudent != null)
            {
                var vm = new ResultsViewModel(SelectedStudent);
                var window = new ResultsWindow(vm);
                window.ShowDialog();
            }
            else
                MessageBox.Show("Please Select Student");
        }
    }
}
