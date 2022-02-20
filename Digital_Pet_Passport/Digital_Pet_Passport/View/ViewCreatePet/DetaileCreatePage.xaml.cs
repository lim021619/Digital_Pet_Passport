using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digital_Pet_Passport.View.ViewCreatePet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetaileCreatePage : ContentPage
    {
        private Pet pet;

        public Pet Pet { get => pet; set { pet = value; OnPropertyChanging(nameof(Pet)); } }

        public DetaileCreatePage(Pet pet)
        {
            Pet = pet;
            InitializeComponent();
            Content.BindingContext = Pet;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ToolbarItems.Add(new ToolbarItem() { Text = "Добавление" });

            await Task.Run(() =>
            {
                new Context.OperationContext().AddPet(Pet);
            });


            MainPage.ViewModel_Pets.Pets.Add(Pet);
            if (!MainPage.ViewModel_Pets.EnableDownloadCollection)
            {
                MainPage.ViewModel_Pets.EnableDownloadFrame = false;
                MainPage.ViewModel_Pets.EnableDownloadCollection = true;
            }

            ToolbarItems.Clear();
            await Navigation.PopToRootAsync();
        }
    }
}