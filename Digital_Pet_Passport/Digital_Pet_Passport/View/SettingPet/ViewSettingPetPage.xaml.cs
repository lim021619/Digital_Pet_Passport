using Digital_Pet_Passport.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digital_Pet_Passport.View.SettingPet
{

    public partial class ViewSettingPetPage : ContentPage
    {
        private ViewSettingPet viewSetting;

        public ViewSettingPet ViewSetting { get => viewSetting; set { viewSetting = value; OnPropertyChanged(nameof(ViewSetting)); } }

        public ViewSettingPetPage(Model.Pet pet)
        {
            ViewSetting = new ViewSettingPet(pet) { Navigation = Navigation };
            InitializeComponent();
            Content.BindingContext = ViewSetting;
            ViewSetting.EmptyNameEvent += CallErrorNameEmpty; 
        }

        /// <summary>
        /// Метод вызывающий всплывающее сообщение
        /// </summary>
        /// <param name="msg"></param>
        public async void CallErrorNameEmpty(OtherModels.Msg msg)
        {
            await DisplayAlert(msg.Title, msg.Message, msg.TextBtn);
        }
       
    }
}