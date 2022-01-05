﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digital_Pet_Passport.View.ViewCreatePet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePage : ContentPage
    {
        private string imagePathAvatar;

        public Model.Pet Pet { get; set; }
        public string ImagePathAvatar { get => imagePathAvatar; set
            {
                imagePathAvatar = value;
                OnPropertyChanged("ImagePathAvatar");
            }
            }
        public CreatePage()
        {
            InitializeComponent();
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Общая информация" });
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Связь с разработчиком" });
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "О приложении" });
            Pet = new Model.Pet();
            ImagePathAvatar = "DefoultPetImage.png";
            RootCont.BindingContext = this;
            sexbut.IsChecked = true;

        }

      

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Pet.Name = Name.Text;
            Pet.Weight = Convert.ToDouble(Weight.Text);
            Pet.Avatar = ImagePathAvatar;
            Pet.Breed = Breed.Text;
            Pet.Kind = Kind.Text;
            Pet.BirthDay.SetAge(BirthDay.Date);
            Pet.ReCalculateAge();
            await Navigation.PushAsync(new View.ViewCreatePet.DetaileCreatePage(Pet));
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                Pet.Sex = radioButton.IsChecked;
            }
        }

        
    }
}