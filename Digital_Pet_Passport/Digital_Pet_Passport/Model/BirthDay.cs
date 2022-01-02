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
        public DateTime SetAge()
        {
            DateTime dt = new DateTime(Year,Mounth, Day);
            TimeSpan reslt = dt.Subtract(DateTime.Now);

            return dt;
        }

    }
}
