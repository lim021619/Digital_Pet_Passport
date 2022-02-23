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
        private ViewModels.ViewCreatePet viewCreatePet;

        public ViewModels.ViewCreatePet ViewCreatePet { get => viewCreatePet; set { viewCreatePet = value; OnPropertyChanged(nameof(ViewCreatePet)); } }

        public CreatePage()
        {
            ViewCreatePet = new ViewModels.ViewCreatePet() { Navigation = Navigation };
            InitializeComponent();
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Общая информация" });
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Связь с разработчиком" });
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "О приложении" });

            Content.BindingContext = ViewCreatePet;

            ViewCreatePet.EmptyNameEvent += CallErrorNameEmpty;
        }

        /// <summary>
        /// Метод вызывающий всплывающее сообщение
        /// </summary>
        /// <param name="msg"></param>
        public async void CallErrorNameEmpty(OtherModels.Msg msg)
        {
            await DisplayAlert(msg.Title, msg.Message, msg.TextBtn);
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}