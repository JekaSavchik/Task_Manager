using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class MyProcess : INotifyPropertyChanged
    {
        private int Id;
        private string NameProces;
        private long MemorySize;

        public int ID
        {
            get { return Id; }
            set
            {
                Id = value;
                OnPropertyChanged("ID");
            }
        }

        public string Name
        {
            get { return NameProces; }
            set
            {
                NameProces = value;
                OnPropertyChanged("Name");
            }
        }
        public long Memory
        {
            get { return MemorySize; }
            set
            {
                MemorySize = value;
                OnPropertyChanged("Memory");
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
