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

        public DetaileCreatePage(Model.Pet pet)
        {
            Pet = pet;
            InitializeComponent();
            RootCont.BindingContext = this;
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ToolbarItems.Add(new ToolbarItem() { Text = "Добавление" });

            await Task.Run(() =>
            {
                new Context.OperationContext().AddPet(Pet);
            });

            
            App.AllPets.Add(Pet);
             
            
            ToolbarItems.Clear();
           await Navigation.PopToRootAsync();
        }
    }
}