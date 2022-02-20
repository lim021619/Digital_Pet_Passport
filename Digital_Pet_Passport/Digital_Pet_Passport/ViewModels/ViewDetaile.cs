using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewDetaile : BaseMVVMViewPet
    {
        private ICommand openWindowSetting;
     
        public ICommand OpenWindowSetting { get => openWindowSetting; set { openWindowSetting = value; OnPropertyChange(nameof(OpenWindowSetting)); } }

        public ViewDetaile(Pet pet)
        {
            Pet = pet;
            OpenWindowSetting = new Command(OpenSetting);
            
        }

        private async void OpenSetting()
        {
            logicWindows.OpenSettingPet(Navigation, Pet);
        }
    }
}
