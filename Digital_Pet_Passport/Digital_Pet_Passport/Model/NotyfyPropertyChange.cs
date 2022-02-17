using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    public class NotyfyPropertyChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
