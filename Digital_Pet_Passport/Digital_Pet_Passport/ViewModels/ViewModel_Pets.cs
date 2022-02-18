using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;    
using System.Text;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewModel_Pets : INotifyPropertyChanged
    {
        private ObservableCollection<Pet> pets;
        private Pet selectedPet;
        private string emptyPets;

        public event PropertyChangedEventHandler PropertyChanged;
        public string EmptyPets { get => emptyPets; set { emptyPets = value; OnPropertyChange(nameof(EmptyPets)); } }
        public ObservableCollection<Pet> Pets { get; set; }

        public Pet SelectedPet { get => selectedPet; set { selectedPet = value; OnPropertyChange(nameof(SelectedPet)); } }

        public ViewModel_Pets()
        {
            emptyPets = string.Empty;
            Pets = new ObservableCollection<Pet>(App.AllPets);
            InitPetsAsync();
        }

        protected void InitPets()
        {
            Context.OperationContext operationContext = new Context.OperationContext();
            
            lock (App.LokingContext)
            {
                foreach (var item in operationContext.GetListPets(true))
                {
                    item.BirthDay.SetAge(item.BirthDay.GetBirthDay());
                    Pets.Add(item);
                }
                //if (App.AllPets.Count != 0)
                //{
                //    //Pets = new ObservableCollection<Pet>();
                //    //foreach (var item in App.AllPets)
                //    //{
                //    //    Pets.Add(item);
                //    //}
                //    Pets = new ObservableCollection<Pet>(App.AllPets);
                //    //FillPets();
                //}
                //else
                //{
                //    EmptyPets = "Pets Empty";
                //}
            }

        }

        private async void InitPetsAsync()
        {   
             await System.Threading.Tasks.Task.Run(InitPets);
        }

        private async void FillPets()
        {

            foreach (var item in App.AllPets)
            {
                await System.Threading.Tasks.Task.Delay(500);

                Pets.Add(item);
            }
        }

        public void OnPropertyChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
