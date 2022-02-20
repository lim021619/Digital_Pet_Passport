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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewSettingPetPage : ContentPage
    {
        private string pathNewImage;
        private string imageName;
        private ViewSettingPet viewSetting;

        public Page DeteilePage { get; set; }
        public Model.Pet Pet { get; set; }


        public ViewSettingPet ViewSetting { get => viewSetting; set { viewSetting = value; OnPropertyChanged(nameof(ViewSetting)); } }

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

            InitializeComponent();
            //System.IO.FileInfo fileInfo = new System.IO.FileInfo(pet.Avatar);
            //imageName = fileInfo.Name;
            PathNewImage = pet.Avatar;
            DeteilePage = new Page();
            Title = $"Редакрирование Питомца";


            Content.BindingContext = ViewSetting = new ViewSettingPet(pet);

            ToolbarItem savechange = new ToolbarItem();
            savechange.Clicked += Savechange_Clicked;
            savechange.Text = "Сохранить";
            ToolbarItems.Add(savechange);

        }

        private async void Savechange_Clicked(object sender, EventArgs e)
        {
            new Context.OperationContext().UpdatePetAsync(Pet);

            await Navigation.PopAsync(true);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            new Context.OperationContext().RemovePet(Pet);
            if (Pet.Avatar != "DefoultPetImage.png")
                new Model.Image().RemoveImage(Pet.Avatar);
            MainPage.ViewModel_Pets.Pets.Remove(Pet);
            await Navigation.PopToRootAsync(true);

        }

        private async void OpenStorageDirectory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ViewDirectory.DirectoryPage(this));

        }

      
    }
}