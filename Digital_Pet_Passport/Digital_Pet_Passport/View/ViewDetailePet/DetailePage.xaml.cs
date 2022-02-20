using Digital_Pet_Passport.Model;
using Digital_Pet_Passport.ViewModels;
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
        private ViewDetaile viewDetaile;

        public ViewDetaile ViewDetaile { get => viewDetaile; set { viewDetaile = value; OnPropertyChanged(nameof(ViewDetaile)); } }
       
        public DetailePage(Pet pet)
        {
            InitializeComponent();
            Content.BindingContext = ViewDetaile = new ViewDetaile(pet) { Navigation = Navigation};
            
        }

        
    }
}