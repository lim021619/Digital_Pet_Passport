using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewCreatePet : NotifyPropertyChange
    {
        private Pet createPet;

        /// <summary>
        /// Добавляемый питомец
        /// </summary>
        public Pet CreatePet { get => createPet; set { createPet = value;  OnPropertyChange(nameof(CreatePet)); } }


      
        public ViewCreatePet()  
        {
            CreatePet = new Pet(); 
            CreatePet.EventChangeSex += CreatePet_EventChangeSex;
            CreatePet.BirthDay.OnFillBirthDate += BirthDay_OnFillBirthDate;
            CreatePet.BirthDay.BirthDatebinding = DateTime.Now;
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
            if (CreatePet.Sex) CreatePet.PathSex = OtherModels.PathImgPets.PathSexWooman;
            else CreatePet.PathSex = OtherModels.PathImgPets.PathSexMan;

        }
    }
}
