using CommunityToolkit.Mvvm.ComponentModel;
using Student_Management_System.Models;
using Student_Management_System.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.ViewModels
{
    public partial class ResultsViewModel:ObservableObject
    {
        [ObservableProperty]
        public Student selectedStudent3;

        [ObservableProperty]
        public ObservableCollection<Module> listRMod;

        [ObservableProperty]
        public ObservableCollection<Module> listMod;

        [ObservableProperty]
        public ObservableCollection<StudentModule> listSM;

        [ObservableProperty]
        public ObservableCollection<StudentModule> listGrade;

        DataBaseContext dbcontext;

        public ResultsViewModel() { }

        public ResultsViewModel(Student student)
        {
            SelectedStudent3 = student;
            dbcontext = new DataBaseContext();
            ListSM = new ObservableCollection<StudentModule>(dbcontext.StudentModules);
            ListMod = new ObservableCollection<Module>(dbcontext.Modules.ToList());
            LoadGradeList();
            LoadRegMod();
        }

        public void LoadGradeList()
        {
            ListGrade = new ObservableCollection<StudentModule>();
            foreach (var sm in ListSM)
            {
                if (sm.StudentReg == SelectedStudent3.RegNo)
                {
                    ListGrade.Add(sm);
                }
            }
        }

        public void LoadRegMod()
        {
            ListRMod = new ObservableCollection<Module>();
            foreach(var sm in ListSM)
            {
                if(sm.StudentReg==SelectedStudent3.RegNo)
                {
                    if(sm.ModuleCode != null)
                    {
                        foreach(var m in ListMod)
                        {
                            if(m.Code == sm.ModuleCode)
                            {
                                ListRMod.Add(m);
                            }
                        }
                    }
                }
            }
        }

    }
}
