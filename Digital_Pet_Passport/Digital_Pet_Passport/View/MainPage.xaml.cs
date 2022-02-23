using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Digital_Pet_Passport
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public static ViewModels.ViewModel_Pets ViewModel_Pets { get; set; }

        /// <summary>
        /// Переменная отвечающая за показ стартового окна. 
        /// Если лож то окно будет показано, в противном случае окно будет скрыто
        /// </summary>
        protected bool EmptyList { get; set; }
        public MainPage()
        {
            ViewModel_Pets = new ViewModels.ViewModel_Pets() { Navigation = Navigation };
            InitializeComponent();
            BindingContext = ViewModel_Pets;
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Общая информация" });
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Связь с разработчиком" });
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "О приложении" });
            
            


        }


       async Task InitStartView()
        {
            //await ContList.FadeTo(0, 1000);
            //ContList.IsVisible = false;
            await LabelNoPetsNewCreate.FadeTo(1, 1000);
            LabelNoPetsNewCreate.IsEnabled = LabelNoPetsNewCreate.IsVisible = true;
            
        }

        
    
      
        /// <summary>
        /// Открытие окна для добавления нового питомца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void EmptyListPets_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ViewCreatePet.CreatePage());
            
        }

    }
}
