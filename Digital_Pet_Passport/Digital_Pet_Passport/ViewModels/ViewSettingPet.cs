using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.ViewModels
{
    public class ViewSettingPet : BaseMVVMViewPet
    {
        private string pathNewImage;
        private string imageName;

        public string ImageName { get => imageName; set { imageName = value; OnPropertyChange(nameof(ImageName)); } }

        public string PathNewImage { get => pathNewImage; set { pathNewImage = value; OnPropertyChange(nameof(PathNewImage)); } }

        public ViewSettingPet(Model.Pet pet)
        {
            Pet = pet;
        }
    }
}
