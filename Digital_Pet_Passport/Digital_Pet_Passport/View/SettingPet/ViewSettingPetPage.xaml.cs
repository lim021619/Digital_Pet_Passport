using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digital_Pet_Passport.View.SettingPet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewSettingPetPage : ContentPage
    {
        public  Model.Pet Pet { get; set; }

        public ViewSettingPetPage(Model.Pet pet)
        {
            Pet = pet;
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            new Context.OperationContext().RemovePet(Pet);
           if(Pet.Avatar != "DefoultPetImage.png") 
                new Model.Image().RemoveImage(Pet.Avatar);
            await Navigation.PopToRootAsync();
           
        }
    }
}