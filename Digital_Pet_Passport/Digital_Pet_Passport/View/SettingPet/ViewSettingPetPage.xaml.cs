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
        private string pathNewImage;
        private string imageName;
        public Page DeteilePage { get; set; }
        public Model.Pet Pet { get; set; }

        public string PathNewImage
        {
            get => pathNewImage; set
            {
                 Pet.Avatar = pathNewImage = value;
                OnPropertyChanged("PathNewImage");

            }
        }
        public string ImageName
        {
            get => imageName; set
            {
                imageName = value;
                OnPropertyChanged("ImageName");
            }
        }
        public ViewSettingPetPage(Model.Pet pet)
        {
            Pet = pet;
            PathNewImage = pet.Avatar;
            DeteilePage = new Page();
            InitializeComponent();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(pet.Avatar);
            imageName = fileInfo.Name;
            RootCont.BindingContext = this;
            Title = $"Редакрирование Питомца";
            ToolbarItem savechange = new ToolbarItem();
            savechange.Clicked += Savechange_Clicked;
            savechange.Text = "Сохранить";
            ToolbarItems.Add(savechange);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }

        private async void Savechange_Clicked(object sender, EventArgs e)
        {
            new Context.OperationContext().UpdatePetAsync(Pet);

            if (DeteilePage is ViewDetailePet.DetailePage d)
            {
                d.updatePet = true;
            }
            await Navigation.PopAsync(true);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            new Context.OperationContext().RemovePet(Pet);
            if (Pet.Avatar != "DefoultPetImage.png")
                new Model.Image().RemoveImage(Pet.Avatar);
            await Navigation.PopToRootAsync(true);

        }

        private async void OpenStorageDirectory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ViewDirectory.DirectoryPage(this));

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (entry != null)
            {
                Pet.Name = entry.Text;
            }
        }

        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (entry != null)
            {
                Pet.Kind = entry.Text;
            }
        }

        private void Entry_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (entry != null)
            {
                Pet.Breed = entry.Text;
            }
        }

        private void Entry_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (entry.Text != String.Empty)
            {
                
                Pet.Weight = Convert.ToDouble(entry.Text);
            }
        }
    }
}