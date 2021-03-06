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
    public partial class CreatePage : ContentPage
    {
        private string imagePathAvatar;
        public Model.Pet Pet { get; set; }

        public ViewModels.ViewCreatePet ViewCreatePet { get; set; }

        public string NamePets { get; set; }
        public string ImagePathAvatar
        {
            get => imagePathAvatar; set
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
            
            Content.BindingContext = ViewCreatePet = new ViewModels.ViewCreatePet();

            Pet = new Model.Pet();
            ImagePathAvatar = "DefoultPetImage.png";
            //RootCont.BindingContext = this;
            sexbut.IsChecked = true;
            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
         
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Pet.Name = Name.Text;
            //Pet.WeightValue = Convert.ToDouble(Weight.Text);
            //Pet.Avatar = ImagePathAvatar;
            //Pet.Breed = Breed.Text;
            //Pet.Kind = Kind.Text;
            //Pet.BirthDay.SetAge(BirthDay.Date);
            //Pet.BirthDay.InitBirthDayDate();
            
            await Navigation.PushAsync(new View.ViewCreatePet.DetaileCreatePage(ViewCreatePet));
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                Pet.Sex = radioButton.IsChecked;
                if (Pet.Sex)
                {
                    Pet.PathSex = "FemaleIcone.png";
                }
                else
                {
                    Pet.PathSex = "MaleImage.png";
                }
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (NamePets != String.Empty && NamePets != null)
            {
                await Navigation.PushAsync(new View.ViewDirectory.DirectoryPage(this));
            }
            else
            {
               await DisplayAlert("Предупреждение","Сначало укажите кличку", "Понятно");
            }
        }

        private void Label_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            NamePets = Name.Text;
        }
    }
}