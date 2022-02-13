using Digital_Pet_Passport.Model;
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

        public Model.Pet Pet { get => pet; set
            {
                pet = value;
                OnPropertyChanged("Pet");
            }
        }
        public bool updatePet = false;
        private Pet pet;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitPet();
        }

        private async Task InitPet()
        {
             await Task.Run(() => {
                if (updatePet)
                {
                    Pet = new Context.OperationContext().GetPetById(Pet.Id, true);
                }
            });

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.SettingPet.ViewSettingPetPage(Pet) { DeteilePage = this});
        }
    }
}