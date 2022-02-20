using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Питомец
    /// </summary>
    public class Pet : Animal
    {
        private event ChangeProperty _changeAvatar;

        private string name;
        private string avatar;
        private string pathSex;
        private ImagePet avatarObject;

        /// <summary>
        /// Кличка
        /// </summary>
        public string Name { get => name; set { name = value; OnPropertyChanged(nameof(Name)); } }

        /// <summary>
        /// Путь до аватра питомца
        /// </summary>
        public string Avatar { get => avatar; set { avatar = value; OnPropertyChanged(nameof(Avatar));  } }

        /// <summary>
        /// Объект предстваляющий аватар питомца
        /// </summary>
        public ImagePet AvatarObject { get => avatarObject; set { avatarObject = value; OnPropertyChanged(nameof(AvatarObject)); } }

        public List<Image> Images { get; set; }

        public string PathSex { get => pathSex; set { pathSex = value; OnPropertyChanged(nameof(PathSex)); } }


        public Pet()
        {
            InitObjct();
            InitEvent();
        }

        public Pet(string name)
        {
            
            InitObjct();
            Name = name;
            InitEvent();

        }

        protected override void InitObjct()
        {
            base.InitObjct();
            Images = new List<Image>();
            Avatar = OtherModels.PathImgPets.PathAvatar;
            //AvatarObject = new ImagePet();
            //AvatarObject.Pet = this;
            //AvatarObject.PetId = Id;
            
        }

        /// <summary>
        /// Задаёт объект аватара питомцу
        /// </summary>
        /// <param name="image"></param>
        public void SetAvatar(ImagePet image)
        {
            AvatarObject = image;
            Avatar= image.PathImage;
        }

        protected virtual void InitEvent()
        {
            _changeAvatar += Pet__changeAvatar;
        }

        private void Pet__changeAvatar()
        {
            if (Avatar!=String.Empty || Avatar != null)
            {

                if (AvatarObject.PathImage != Avatar)
                {
                    AvatarObject.PathImage = Avatar;
                    AvatarObject.Name = $"{Name}_|_{Avatar}";
                    AvatarObject.Avatar = true;
                }
                
            }
        }
    }
}
