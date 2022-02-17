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
        private string name;
        private string avatar;
        private string pathSex;

        /// <summary>
        /// Кличка
        /// </summary>
        public string Name { get => name; set { name = value; OnPropertyChanged(nameof(Name)); } }

        public string Avatar { get => avatar; set { avatar = value; OnPropertyChanged(nameof(Avatar)); } }

        public List<Image> Images { get; set; }

        public string PathSex { get => pathSex; set { pathSex = value;  OnPropertyChanged(nameof(PathSex)); }  }


        public Pet()
        {

        }

        public Pet(string name)
        {

            InitObjct();
            Name = name;

        }

        protected override void InitObjct()
        {
            base.InitObjct();
            Images = new List<Image>();
        }

    }
}
