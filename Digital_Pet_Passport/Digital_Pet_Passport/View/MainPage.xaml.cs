using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Digital_Pet_Passport
{
    public partial class MainPage : ContentPage
    {
        public System.Collections.ObjectModel.ObservableCollection<Model.Pet> PetsCollection { get; set; }
         List<Model.Pet> Petlists { get; set; }
        object petslistlock= new object();
        public Context.OperationContext OperationContext { get; set; }

        /// <summary>
        /// Переменная отвечающая за показ стартового окна. 
        /// Если лож то окно будет показано, в противном случае окно будет скрыто
        /// </summary>
        protected bool EmptyList { get; set; }
        public MainPage()
        {
            InitializeComponent();

            SetValue(NavigationPage.BarBackgroundColorProperty, Color.Red);
            PetsCollection = new System.Collections.ObjectModel.ObservableCollection<Model.Pet>();
            Petlists = new List<Model.Pet>();
            Content.BindingContext = this;
            OperationContext = new Context.OperationContext();
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Общая информация" });
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Связь с разработчиком" });
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "О приложении" });
            //new Context.OperationContext().AddPet(new Model.Pet("ласка"));
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(PetsCollection.Count != 0) PetsCollection.Clear();
            
            DownloadPetsAsync();
            
        }

        void InitPorp()
        {

        }


        async void DownloadPetsAsync()
        {
            DownloadPets();

            //lock ( petslistlock)
            //{
            //    foreach (var item in Petlists)
            //    {
            //        PetsCollection.Add(item);
            //    }
            //}
            
        }

       async Task InitStartView()
        {
            await ContList.FadeTo(0, 1000);
            ContList.IsVisible = false;
            await LabelNoPetsNewCreate.FadeTo(1, 1000);
            LabelNoPetsNewCreate.IsEnabled = LabelNoPetsNewCreate.IsVisible = true;
            
        }

        async void DownloadPets()
        {
            lock (App.LokingContext)
            {
                if (App.CountPets != 0)
                {
                    lock (petslistlock)
                    {
                        ContList.FadeTo(1, 1000);
                        LabelNoPetsNewCreate.IsVisible = false;
                        ContList.IsVisible = true;
                        List<Model.Pet> pets = OperationContext.GetListPets(false);

                        foreach (Model.Pet item in pets)
                        {
                            var f = item;
                            if (item.Avatar == String.Empty || item.Avatar == null)
                            {
                                f.Avatar = "DefoultPetImage.png";
                            }
                            if (f.Sex)
                            {
                                f.PathSex = "FemaleIcone.png";
                            }
                            else
                            {
                                f.PathSex = "MaleImage.png";
                            }


                            PetsCollection.Add(f);
                        }

                    }
                }
                else
                {

                    InitStartView();
                }
            }

        }


        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Pets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count != 0)
            {
                Model.Pet pet = e.CurrentSelection[0] as Model.Pet;
                ///Создание окна просмотра и редактирования элемента
                CollectionView colview = (CollectionView)sender;
                colview.SelectedItem = null;
            }
        }

        private void EmptyListPets_Clicked_1(object sender, EventArgs e)
        {
            new Context.OperationContext().AddPet(new Model.Pet("ласка"));
            App.CountPets += 1;
            DownloadPets();
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
