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
        public Model.Pet Pet { get; set; }

        public ViewModels.ViewCreatePet ViewCreatePet { get; set; }

        public DetaileCreatePage(ViewModels.ViewCreatePet pet)
        {
            ViewCreatePet = pet;
            InitializeComponent();
            Content.BindingContext = ViewCreatePet;
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ToolbarItems.Add(new ToolbarItem() { Text = "Добавление" });

            await Task.Run(() =>
            {
                new Context.OperationContext().AddPet(ViewCreatePet.CreatePet);
            });


            MainPage.ViewModel_Pets.Pets.Add(ViewCreatePet.CreatePet);
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