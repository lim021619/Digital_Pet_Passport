using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewDetaile : NotifyPropertyChange
    {
        private Pet myProperty;
        private ICommand openWindowSetting;

        public Pet Pet { get => myProperty; set { myProperty = value; OnPropertyChange(nameof(Pet)); } }

        public ICommand OpenWindowSetting { get => openWindowSetting; set { openWindowSetting = value; OnPropertyChange(nameof(OpenWindowSetting)); } }

        public INavigation Navigation { get; set; }

        public ViewDetaile(Pet pet)
        {
            Pet = pet;
            OpenWindowSetting = new Command(OpenSetting);
        }

        private async void OpenSetting()
        {
            await Navigation.PushAsync(new View.SettingPet.ViewSettingPetPage(Pet));
        }
    }
}
