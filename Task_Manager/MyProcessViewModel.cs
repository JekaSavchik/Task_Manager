using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class MyProcessViewModel : INotifyPropertyChanged
    {
        private MyProcess selectedProcess;
        public ObservableCollection<MyProcess> MyProcesses { get; set; } = new ObservableCollection<MyProcess>();
        private RelayCommand loadprocesses;
        public MyProcess SelectedProcess
        {
            get { return selectedProcess; }
            set
            {
                selectedProcess = value;
                OnPropertyChanged("SelectedProcess");
            }
        }

        public MyProcessViewModel()
        {
            MyProcesses = new ObservableCollection<MyProcess>();
        }
        public RelayCommand Load_Processes
        {
            get
            {
                return loadprocesses ?? (loadprocesses = new RelayCommand(LoadProcess));
            }
        }

        public void LoadProcess()
        {
            foreach (Process process in Process.GetProcesses())
            {
                MyProcesses.Add(new MyProcess { Name = process.ProcessName, ID = process.Id, Memory = process.PrivateMemorySize64 });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
