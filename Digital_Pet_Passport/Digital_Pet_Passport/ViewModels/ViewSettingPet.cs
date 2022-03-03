using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewSettingPet : BaseMVVMViewPet, IDisposable
    {
        private string pathNewImage;
        private string imageName;
        private ICommand saveChange;
        private ICommand deletePet;
        private ICommand openDirectory;

        public string ImageName { get => imageName; set { imageName = value; OnPropertyChange(nameof(ImageName)); } }

        public string PathNewImage { get => pathNewImage; set { pathNewImage = value; OnPropertyChange(nameof(PathNewImage)); } }

        public ICommand SaveChange { get => saveChange; set { saveChange = value; OnPropertyChange(nameof(SaveChange)); } }
        public ICommand DeletePet { get => deletePet; set { deletePet = value; OnPropertyChange(nameof(DeletePet)); } }
        public ICommand OpenDirectory { get => openDirectory; set { openDirectory = value; OnPropertyChange(nameof(OpenDirectory)); } }

        public ViewSettingPet(Model.Pet pet)
        {
            Pet = pet;
            Pet.SetWeightNow();
            InitPropAsync();
        }

        async void InitPropAsync()
        {
            await System.Threading.Tasks.Task.Run(InitProp);
        }

        void InitProp()
        {
            System.IO.FileInfo avatar = new System.IO.FileInfo(Pet.Avatar);
            ImageName = avatar.Name;
            SaveChange = new Command(Save);
            DeletePet = new Command(Delete);
            OpenDirectory = new Command(OpenStorageDirectory);
            OtherModels.ImgDirectory.DropEvent();
            if (Pet.AvatarObject != null)
            {
                OtherModels.ImgDirectory.changeName += ImgDirectory_changeName;
                OtherModels.ImgDirectory.changePath += ImgDirectory_changePath;
            }
            else
            {
                OtherModels.ImgDirectory.changePath += () => 
                {
                    Pet.Avatar = OtherModels.ImgDirectory.PathImg;
                    OtherModels.ImgDirectory.DropeDataAsync();
                };
            }
            EmptyNameEvent += ViewSettingPet_EmptyNameEvent;
        }

        /// <summary>
        /// Инициализация сообщения предупреждения
        /// </summary>
        /// <param name="msg"></param>
        private void ViewSettingPet_EmptyNameEvent(OtherModels.Msg msg)
        {
            msg.Title = "Предупреждение";
            msg.Message = "Нельзя оставить питомца без клички. Введите пожалуйста кличку!";
            msg.TextBtn = "Я понял(а)";
        }

        private void ImgDirectory_changePath()
        {
            string path = OtherModels.ImgDirectory.PathImg;

            if (!string.IsNullOrEmpty(path))
            {
                Pet.AvatarObject.PathImage = path;
                Pet.Avatar = path;
                OtherModels.ImgDirectory.DropeDataAsync();
            }

            
        }
        /// <summary>
        /// Инициализация изображения в питомце
        /// </summary>
        private void ImgDirectory_changeName()
        {
            if (!string.IsNullOrEmpty(OtherModels.ImgDirectory.NameImg))
            { 
                Pet.AvatarObject.Name = OtherModels.ImgDirectory.NameImg;
                OtherModels.ImgDirectory.DropeDataAsync();
            }
        }

        /// <summary>
        /// Событие кнопки сохранить
        /// </summary>
        async void Save()
        {
            if (ChekName(true))
            {
                App.OperationContext.UpdatePetAsync(Pet);
                await Navigation.PopAsync(true);
            }
        }

        /// <summary>
        /// Событие кнопки удалить
        /// </summary>
        async void Delete()
        {
            new Context.OperationContext(App.Contextdb).RemovePet(Pet);
            if (Pet.Avatar != OtherModels.PathImgPets.PathStdIcon)
            {
                new Model.Image().RemoveImage(Pet.Avatar);
            }
            MainPage.ViewModel_Pets.Pets.Remove(Pet);
            await Navigation.PopToRootAsync(true);
        }
        
        /// <summary>
        /// Событие поиска избражения
        /// </summary>
        async void OpenStorageDirectory()
        {
            ViewDirectory.NamePet = Pet.Name;
            await Navigation.PushAsync(new View.ViewDirectory.DirectoryPage(Enums.OptionDirectory.Setting));
        }

        public void Dispose()
        {
            OtherModels.ImgDirectory.changeName -= ImgDirectory_changeName;
            OtherModels.ImgDirectory.changePath -= ImgDirectory_changePath;
        }
    }
}
