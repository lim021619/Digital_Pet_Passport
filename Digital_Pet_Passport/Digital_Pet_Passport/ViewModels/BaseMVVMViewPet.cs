using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Digital_Pet_Passport.ViewModels
{
    public class BaseMVVMViewPet : NotifyPropertyChange
    {
        private Pet pet;

        public Pet Pet { get => pet; set { pet = value; OnPropertyChange(nameof(Pet)); } }
        public INavigation Navigation { get; set; }

        protected OtherModels.LogicWindows logicWindows { get; set; }

        public BaseMVVMViewPet()
        {
            logicWindows = new OtherModels.LogicWindows();
              
        }
        
    }
}
