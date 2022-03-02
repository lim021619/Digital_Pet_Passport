using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewDetaileCreate : BaseMVVMViewPet
    {
        private string addingProcess = string.Empty;
        public ICommand AddNewPet { get; set; }

        public string AddingProcess { get => addingProcess; set { addingProcess = value;} }

        public ViewDetaileCreate(Model.Pet pet)
        {
            Pet = pet;
            AddNewPet = new Command(AddPet);
        }

        private void AddPet(object obj)
        {
            AddingProcess = "Добавлеие";
            ValidationImageobject();
            AddPetDbAsync();

            MainPage.ViewModel_Pets.Pets.Add(Pet);
            if (!MainPage.ViewModel_Pets.EnableDownloadCollection)
            {
                MainPage.ViewModel_Pets.EnableDownloadFrame = false;
                MainPage.ViewModel_Pets.EnableDownloadCollection = true;
            }

            AddingProcess = string.Empty;

            new OtherModels.LogicWindows().OpenRootWindow(Navigation);

        }

        private void ValidationImageobject()
        {
            if (Pet.AvatarObject != null)
            {
                Pet.AvatarObject = new Model.ImagePet();
                Pet.AvatarObject.PathImage = Pet.Avatar;
            }
        }

        private void AddPetDb()
        {
            Pet.AddWeightNow();
            App.OperationContext.AddPet(Pet);
        }
        private async void AddPetDbAsync()
        {
            await System.Threading.Tasks.Task.Run(AddPetDb);
        }
    }
}
