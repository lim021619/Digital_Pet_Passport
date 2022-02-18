using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Digital_Pet_Passport.Tests.TestNotifyProppetryChanged
{
    public class NPCH : INotifyPropertyChanged
    {
        private int id;
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get => id; set { id = value; OnPropertyChanged(nameof(Id)); } }

        public string Name { get => name; set { name = value; OnPropertyChanged(nameof(Name)); } }

        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


    }
}
