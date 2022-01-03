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
        public Context.OperationContext OperationContext { get; set; }
        public MainPage()
        {
            InitializeComponent();
            PetsCollection = new System.Collections.ObjectModel.ObservableCollection<Model.Pet>();
            Content.BindingContext = this;
            Pets.ItemsSource = PetsCollection;
            OperationContext = new Context.OperationContext();

            OperationContext.AddPet(new Model.Pet("Ласка") { Age = 3, Breed = "Сенергети", Kind = "Кошка", Sex = true, Weight = 4.9});

        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DownloadPets();


        }

        void InitPorp()
        {
            
        }

        
        void DownloadPets()
        {

            foreach (Model.Pet item in OperationContext.GetListPets(false))
            {
                PetsCollection.Add(item);
            }

            
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
                
        }
    }
}
