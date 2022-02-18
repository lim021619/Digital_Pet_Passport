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
            
        }

    }
}
