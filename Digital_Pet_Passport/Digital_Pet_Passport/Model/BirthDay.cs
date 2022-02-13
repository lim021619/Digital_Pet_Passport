using Digital_Pet_Passport.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Дата рождения
    /// </summary>
    public class BirthDay : IContext
    {
        public int Id { get; set; }
        /// <summary>
        /// Год рождения
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Месяц рождения
        /// </summary>
        public int Mounth { get; set; }
        /// <summary>
        /// День рождения
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// Id питомца
        /// </summary>
        public int AnimalId { get; set; }
        /// <summary>
        /// Питомец
        /// </summary>
        public Animal Animal { get; set; }

        public string BirthDayDate { get; set; }


        public BirthDay()
        {
           if(Year != 0 && Mounth != 0 && Day != 0) BirthDayDate = InitBirthDayDate();
        }

        /// <summary>
        /// Возвращает дату рождения питомца
        /// </summary>
        /// <returns></returns>
        public DateTime GetBirthDay()
        {
            return new DateTime(Year, Mounth, Day);

        }

        /// <summary>
        /// Метод инициализирующий возраст животоного
        /// </summary>
        /// <returns></returns>
        public void SetAge(DateTime dateTime)
        {
            Day = dateTime.Day;
            Year = dateTime.Year;
            Mounth = dateTime.Month;
            BirthDayDate = InitBirthDayDate();
        }

        string InitBirthDayDate()
        {
           return  new DateTime(Year, Mounth, Day).ToLongDateString();
        }

        public int CalculateMounth(ref int NumberMounth, int ageToDay)
        {

            if (ageToDay >= DateTime.DaysInMonth(Year, Mounth))
            {
                ageToDay -= DateTime.DaysInMonth(Year,Mounth);
                NumberMounth++;
                CalculateMounth(ref NumberMounth, ageToDay);
            }

            return NumberMounth; 
        }
    }
}
