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
        //public System.Collections.ObjectModel.ObservableCollection<Model.Pet> PetsCollection { get; set; }
        // List<Model.Pet> Petlists { get; set; }
        //object petslistlock= new object();
        //public Context.OperationContext OperationContext { get; set; }

        public ViewModels.ViewModel_Pets ViewModel_Pets { get; set; }

        /// <summary>
        /// Переменная отвечающая за показ стартового окна. 
        /// Если лож то окно будет показано, в противном случае окно будет скрыто
        /// </summary>
        protected bool EmptyList { get; set; }
        public MainPage()
        {
            InitializeComponent();

            
            //PetsCollection = new System.Collections.ObjectModel.ObservableCollection<Model.Pet>();
            //Petlists = new List<Model.Pet>();
            //PetsCollection = App.AllPets;
            
            //Content.BindingContext = this;
            //OperationContext = new Context.OperationContext();
            Content.BindingContext = ViewModel_Pets = new ViewModels.ViewModel_Pets();
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Общая информация" });
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Связь с разработчиком" });
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "О приложении" });
            
            //new Context.OperationContext().AddPet(new Model.Pet("ласка"));
        }


       async Task InitStartView()
        {
            //await ContList.FadeTo(0, 1000);
            //ContList.IsVisible = false;
            await LabelNoPetsNewCreate.FadeTo(1, 1000);
            LabelNoPetsNewCreate.IsEnabled = LabelNoPetsNewCreate.IsVisible = true;
            
        }

        
        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Pets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count != 0)
            {
                Model.Pet pet = e.CurrentSelection[0] as Model.Pet;

                await Navigation.PushAsync(new View.ViewDetailePet.DetailePage(pet));
                ///Создание окна просмотра и редактирования элемента
                CollectionView colview = (CollectionView)sender;
                colview.SelectedItem = null;
            }
        }

        private async void EmptyListPets_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ViewCreatePet.CreatePage());
            ///Открытие окна для добавления нового питомца
        }

        /// <summary>
        /// Метод меняющий значение ссылочного параметра на обратный от переданного в первом параметре.
        /// </summary>
        /// <param name="flag">Флаг обратного значения</param>
        /// <param name="changeFlag">Флаг изменяющего значения</param>
        void ChangeFlag(bool flag,ref bool changeFlag)
        {
            if (flag)
            {
                changeFlag = false;
            }
            else
            {
                changeFlag |= true  ;
            }
        }
    }
}
