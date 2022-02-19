using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;    
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewModel_Pets : INotifyPropertyChanged
    {
        private Pet selectedPet;
        private string emptyPets = "Поиск питомцев";
        private ICommand commandOpenDeteilPet;
        
        private bool enableDownloadFrame = true;
        private bool enableDownloadCollection = false;
        private string textaddNewPet1 = "Добавить питомца";
        private ICommand clickStartOpen;

        /// <summary>
        /// Свойство навигиации
        /// </summary>
        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Строка представляюща имеются ли питомцы в базе данных
        /// </summary>
        public string EmptyPets { get => emptyPets; set { emptyPets = value; OnPropertyChange(nameof(EmptyPets)); } }
        /// <summary>
        /// Питомы
        /// </summary>
        public ObservableCollection<Pet> Pets { get; set; }
        /// <summary>
        /// Выбранный питомец
        /// </summary>
        public Pet SelectedPet
        {
            get => selectedPet;
            set
            {
                if (value == selectedPet) return;
                selectedPet = value;
                OnPropertyChange(nameof(SelectedPet));
            }
        }
        
        public ICommand CommandOpenDeteilPet
        {
            get => commandOpenDeteilPet; set
            {
                commandOpenDeteilPet = value;
                OnPropertyChange(nameof(CommandOpenDeteilPet));
            }
        }

        public ICommand ClickStartOpen { get => clickStartOpen; set { clickStartOpen = value;  OnPropertyChange(nameof(ClickStartOpen)); }  }

        public bool EnableDownloadFrame { get => enableDownloadFrame; set { enableDownloadFrame = value; OnPropertyChange(nameof(EnableDownloadFrame)); } }
        public bool EnableDownloadCollection { get => enableDownloadCollection; set { enableDownloadCollection = value; OnPropertyChange(nameof(EnableDownloadCollection)); } }

        public string textaddNewPet { get => textaddNewPet1; set { textaddNewPet1 = value; OnPropertyChange(nameof(textaddNewPet)); } }
        public ViewModel_Pets()
        {
            EnableDownloadFrame = true;
            CommandOpenDeteilPet = new Command(OpenNewDeteilePet);
            Pets = new ObservableCollection<Pet>();
            SelectedPet = new Pet();
            InitPetsAsync();
            CreatPet();
        }

        /// <summary>
        /// Метод Асинронно инициализирует свойство питомцы
        /// </summary>
        private async void InitPetsAsync()
        {
            await System.Threading.Tasks.Task.Run(FillPets);
        }
        /// <summary>
        /// Метод инициализирующий свойства питомцы
        /// </summary>
        private void FillPets()
        {
            lock (App.LokingContext)
            {

                foreach (var item in App.OperationContext.GetListPets(true))
                {
                    item.BirthDay.SetAge(item.BirthDay.GetBirthDay());

                    Pets.Add(item);
                }


                if (Pets.Count != 0)
                {
                    EmptyPets = $"Найдено {Pets.Count} питомцев";

                    Continue();
                }
                else
                {
                    
                    EmptyPets = "Пока нет ни одного питомца";

                }

            }

        }

        public void OnPropertyChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        /// <summary>
        /// Метод который прикреплён к команде выбора питомца
        /// </summary>
        void OpenNewDeteilePet()
        {
            DetailPet();
        }

        /// <summary>
        /// Открытие окна просмотра питомца и сброс выбрнного питомца
        /// </summary>
        private async void DetailPet()
        {
            if (SelectedPet != null)
            {
                await Navigation.PushAsync(new View.ViewDetailePet.DetailePage(SelectedPet), true);
                SelectedPet = null;
            }
        }

        async void CreatPet()
        {
            ClickStartOpen = new Command(nullPets);
            
        }

        async void nullPets()
        {
            await Navigation.PushAsync(new View.ViewCreatePet.CreatePage(), true);

        }

        async void Continue()
        {
            textaddNewPet = "Продолжить";
            ClickStartOpen = new Command(HideStartWindow);
            
        }

        async void HideStartWindow()
        {
            await System.Threading.Tasks.Task.Run(() => {
                EnableDownloadFrame = false;
                EnableDownloadCollection = true;
            });
            
        }

    }
}
