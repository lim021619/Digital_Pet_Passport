using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewCreatePet : BaseMVVMViewPet, IDisposable
    {
        public ICommand OpenDirectory { get; set; }
        public ICommand OpenDetaileCreate { get; set; }

        public ViewCreatePet()
        {
            Pet.EventChangeSex += CreatePet_EventChangeSex;
            Pet.BirthDay.OnFillBirthDate += BirthDay_OnFillBirthDate;
            EmptyNameEvent += ViewCreatePet_EmptyNameEvent;

            OtherModels.ImgDirectory.DropEvent();

            OtherModels.ImgDirectory.changePath += ImgDirectory_changePath;
            OtherModels.ImgDirectory.changeName += ImgDirectory_changeName;
            
            Pet.BirthDay.BirthDatebinding = DateTime.Now;
            OpenDirectory = new Command(OpenDirectoryPage);
            OpenDetaileCreate = new Command(OpenDetaileCreatePage);

        }

        private void ViewCreatePet_EmptyNameEvent(OtherModels.Msg msg)
        {
            msg.Title = "Предупреждение";
            msg.Message = "Сначало укажите кличку";
            msg.TextBtn = "Понятно";
        }

        private async void OpenDetaileCreatePage()
        {
           if(ChekName(true)) await Navigation.PushAsync(new View.ViewCreatePet.DetaileCreatePage(Pet));
        }

        private async void OpenDirectoryPage()
        {
            if (ChekName(true))
            {
                ViewDirectory.NamePet = Pet.Name;
                await Navigation.PushAsync(new View.ViewDirectory.DirectoryPage(Enums.OptionDirectory.Create));
            }
            
        }

        private void ImgDirectory_changeName()
        {
            if (!string.IsNullOrEmpty(OtherModels.ImgDirectory.NameImg) && Pet.AvatarObject != null)
            {
                Pet.AvatarObject.Name = OtherModels.ImgDirectory.NameImg;
                OtherModels.ImgDirectory.DropeDataAsync();
            }
                
                
        }

        private void ImgDirectory_changePath()
        {
            string path = OtherModels.ImgDirectory.PathImg;

            if (!string.IsNullOrEmpty(path))
            {
               if(Pet.AvatarObject != null) Pet.AvatarObject.PathImage = path;
                Pet.Avatar = path;
                OtherModels.ImgDirectory.DropeDataAsync();
            }
        }

        private async void BirthDay_OnFillBirthDate(BirthDay birthDay)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                birthDay.InitLiveAgeFlag = false;
                birthDay.SetAge(birthDay.BirthDatebinding);

            });

        }

        private async void CreatePet_EventChangeSex()
        {
            await System.Threading.Tasks.Task.Run(ChangeSex);
            
        }

        private void ChangeSex()
        {
            if (Pet.Sex) { Pet.PathSex = OtherModels.PathImgPets.PathSexWooman; Pet.WordCastration = Animal.Wooman; Pet.ResulteCastString = Animal.WordWoomanSter; }
            else { Pet.PathSex = OtherModels.PathImgPets.PathSexMan; Pet.WordCastration = Animal.Man; Pet.ResulteCastString = Animal.WordCast; }
            
        }

        public void Dispose()
        {
            OtherModels.ImgDirectory.changePath -= ImgDirectory_changePath;
            OtherModels.ImgDirectory.changeName -= ImgDirectory_changeName;
        }

        ~ViewCreatePet()
        {
            Pet = null;
        }
    }
}
