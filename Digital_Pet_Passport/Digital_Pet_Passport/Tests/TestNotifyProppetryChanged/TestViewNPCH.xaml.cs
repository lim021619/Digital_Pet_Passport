using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digital_Pet_Passport.Tests.TestNotifyProppetryChanged
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestViewNPCH : ContentPage
    {
        public ViewModelNPCH ss { get; set; }

        public TestViewNPCH()
        {
            
            
            InitializeComponent();
            Content.BindingContext = new ViewModelNPCH(); ;

        }
    }
}