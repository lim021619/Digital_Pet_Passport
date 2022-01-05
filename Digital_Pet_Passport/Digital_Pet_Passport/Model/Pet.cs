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
        /// <summary>
        /// Кличка
        /// </summary>
        public string Name { get; set; }

        public string Avatar { get; set; }

        public  List<Image> Images { get; set; }

        [NotMapped]
        public string PathSex { get; set; }


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
