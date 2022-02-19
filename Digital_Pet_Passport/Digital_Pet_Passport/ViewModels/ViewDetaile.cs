using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewDetaile : NotifyPropertyChange
    {
        private Pet myProperty;

        public Pet Pet { get => myProperty; set { myProperty = value; OnPropertyChange(nameof(Pet)); }  }
    }
}
