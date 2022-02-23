
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digital_Pet_Passport.View.ViewDirectory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectoryPage : ContentPage
    {
        private ViewModels.ViewDirectory viewDirectory;

        public ViewModels.ViewDirectory ViewDirectory { get => viewDirectory; set { viewDirectory = value; } }

        public DirectoryPage(Enums.OptionDirectory mode, string path = "")
        {
            InitPage(mode, path);
        }

        private void ViewDirectory_IsEnableToolBarItemAddingImg()
        {
            tlbAdd.IsEnabled = ViewDirectory.IsEnableSelectImg;
        }

        private void OffTlbadd() => tlbAdd.IsEnabled = false;

        private void InitPage(Enums.OptionDirectory mode, string path = "")
        {
            InitializeComponent();
            BindingContext = ViewDirectory = new ViewModels.ViewDirectory(mode, path) { Navigation = Navigation };
            OffTlbadd();
            ViewDirectory.IsEnableToolBarItemAddingImg += ViewDirectory_IsEnableToolBarItemAddingImg;

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            

        }
    }
}