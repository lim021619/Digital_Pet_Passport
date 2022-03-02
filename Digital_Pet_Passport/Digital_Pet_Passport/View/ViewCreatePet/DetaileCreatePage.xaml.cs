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
        public ViewModels.ViewDetaileCreate ViewDetaileCreate { get; set; }

        public DetaileCreatePage(Pet pet)
        {
            ViewDetaileCreate = new ViewModels.ViewDetaileCreate(pet) { Navigation = Navigation};
            InitializeComponent();
            BindingContext = ViewDetaileCreate;
            
        }

        
    }
}