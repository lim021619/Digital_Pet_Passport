using Digital_Pet_Passport.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Животоное
    /// </summary>
    public class Animal : IContext
    {
        private int age;
        private string outAge;

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
        public int Age
        {
            get => age; set
            {

                age = value;
                SetOutAge();
            }
        }
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

        
        [NotMapped]
        public string OutAge { get { return outAge; } set
            {
               
                outAge = value;
               
            } }
        public Animal()
        {
            BirthDay = new BirthDay();
        }

        void SetOutAge()
        {
            if (Age != 0)
            {
                int y = Age / 365;
                int yo = Age % 365;
                if (y >= 1)
                {
                    outAge = $"{y.ToString()} г.";
                }
                else
                {
                    int m = Age / 12;
                    int mo = Age % 12;
                    if (m > 0)
                    {
                        outAge = $"{m.ToString()} мес";
                    }
                    else
                    {
                        outAge = $"{mo.ToString()} дн";
                    }
                }
            }
        }


        virtual protected void InitObjct()
        {
            InitProp();
        }

        virtual protected void InitProp()
        {
            BirthDay = new BirthDay();
            BirthDay.Animal = this;
        }

        public void ReCalculateAge()
        {
            TimeSpan timeSpan = TimeSpan.Zero;
            DateTime birthday = BirthDay.GetBirthDay();
            timeSpan = DateTime.Now.Date - birthday.Date;
            Age = ((int)timeSpan.TotalDays);

        }


    }
}
