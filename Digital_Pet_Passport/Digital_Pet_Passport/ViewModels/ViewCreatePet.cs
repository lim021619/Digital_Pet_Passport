using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewCreatePet : BaseMVVMViewPet
    {
        public ViewCreatePet()  
        {
            Pet = new Pet(); 
            Pet.EventChangeSex += CreatePet_EventChangeSex;
            Pet.BirthDay.OnFillBirthDate += BirthDay_OnFillBirthDate;
            Pet.BirthDay.BirthDatebinding = DateTime.Now;
        }

        private async void BirthDay_OnFillBirthDate(BirthDay birthDay)
        {
            
            
            await System.Threading.Tasks.Task.Run(() => {

                birthDay.InitLiveAgeFlag = false;
                birthDay.SetAge(birthDay.BirthDatebinding);
                
            });
            
        }

        private async void CreatePet_EventChangeSex()
        {
            await System.Threading.Tasks.Task.Run(ChangeSexImage);            
        }

        private void ChangeSexImage()
        {
            if (Pet.Sex) Pet.PathSex = OtherModels.PathImgPets.PathSexWooman;
            else Pet.PathSex = OtherModels.PathImgPets.PathSexMan;

        }
    }
}
