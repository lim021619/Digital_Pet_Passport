using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    public class Manipulaton
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public int Mounth { get; set; }

        public int Day { get; set; }

        public EManipulation TypeManipulaton { get; set;}

        public Animal Animal { get; set; }

        public int AnimalId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DateTime Date { get; set; }

        public Manipulaton()
        {
            if (chekIntZero(Year) && chekIntZero(Mounth) && chekIntZero(Day))
            {
                Date = new DateTime(Year, Mounth, Day);
            }
        }

        public Manipulaton(EManipulation manipulation)
        {
            TypeManipulaton = manipulation;
            Year = DateTime.Now.Year;
            Mounth = DateTime.Now.Month;
            Day = DateTime.Now.Day;
        }

        bool chekIntZero(int x)
        {
            if (x != 0)
            {
                return true;
            }

            return false;
        }
    }

}
