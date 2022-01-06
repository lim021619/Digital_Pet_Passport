using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digital_Pet_Passport.View.ViewDetailePet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailePage : ContentPage
    {

        public Model.Pet Pet { get; set; }

        public DetailePage()
        {
            InitializeComponent();
        }
        public DetailePage(Model.Pet pet)
        {
            Pet = pet;
            InitializeComponent();
            RootCont.BindingContext = this;
            Title = $"Питомец {Pet.Name}";
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.SettingPet.ViewSettingPetPage(Pet));
        }
    }
}