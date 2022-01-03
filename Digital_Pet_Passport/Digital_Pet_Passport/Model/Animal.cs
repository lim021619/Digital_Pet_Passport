using Digital_Pet_Passport.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Животоное
    /// </summary>
    public class Animal : IContext
    {
        private int age;

        public int Id { get; set; }

        /// <summary>
        /// Порода
        /// </summary>
        public string Breed { get; set; }
        /// <summary>
        /// Вид
        /// </summary>
        public string Kind { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get => age; set {

                age = value;

            }  }
        /// <summary>
        /// Вес животного
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Определяет пол животного False - кабель, True - сука
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public BirthDay BirthDay { get; set; }


       virtual protected void InitObjct()
       {
            InitProp();
       }

       virtual protected void InitProp()
       {
            BirthDay = new BirthDay();  
            BirthDay.Animal = this;
       }


    }
}
