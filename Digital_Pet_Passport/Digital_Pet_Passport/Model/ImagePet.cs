using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Класс представлющий изображение питомцев
    /// </summary>
    public class ImagePet : NotifyPropertyChange, Intefaces.IContext
    {
        protected delegate void ChangeAvatar();
        protected event ChangeAvatar OnAvatarChanged;
        
        private string name;
        private string pathImage;
        private bool avatar;

        public bool Avatar
        {
            get => avatar; set
            {
                avatar = value; if (avatar)
                {
                    OnAvatarChanged?.Invoke();
                }
                
            }  }
        public string Name { get => name; set { name = value; OnPropertyChange(nameof(Name)); } }

        public string PathImage { get => pathImage; set { pathImage = value; OnPropertyChange(nameof(PathImage)); } }

        public int Id { get; set; }

        public Pet Pet { get; set; }

        public int PetId { get; set; }

        public ImagePet()
        {
            InitEvents();
        }

        private void InitEvents()
        {
            OnAvatarChanged += ImagePet_OnAvatarChanged;
        
        }

        private void ImagePet_OnAvatarChanged()
        {
            Pet.Avatar = PathImage;
        }

        void DropAvatarToPetAsync()
        {

        }
        void  DropAvatarToPet()
        {
           
        }
    }

}

