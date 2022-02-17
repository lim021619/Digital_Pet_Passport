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
        }

        protected void InitPets()
        {
            if (App.AllPets.Count != 0)
            {
                foreach (var item in App.AllPets)
                {
                    Pets.Add(item);
                }
            }
            else
            {
                EmptyPets = "Pets Empty";
            }
        }

        protected void OnPropertyChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
