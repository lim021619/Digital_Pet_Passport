using Digital_Pet_Passport.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    public class Image : IContext
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int PetsId { get; set; }

        public Pet Pet { get; set; }


        /// <summary>
        /// Сохранение изображения в приложении
        /// </summary>
        public void SaveImg()
        {

        }


    }
}
