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
            InitializeComponent();
            Pet = pet;
        }
    }
}