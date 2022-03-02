using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    public class Manipulaton : NotifyPropertyChange
    {
        private string name;
        private int year;
        private int mounth;
        private int day;

        public int Id { get; set; }

        public string Name { get => name; set { name = value; OnPropertyChange(nameof(Name)); } }

        public int Year { get => year; set { year = value; OnPropertyChange(nameof(Year)); } }

        public int Mounth { get => mounth; set { mounth = value; OnPropertyChange(nameof(Mounth)); } }

        public int Day { get => day; set { day = value; OnPropertyChange(nameof(Day)); } }

        public EManipulation TypeManipulaton { get; set; }

        public Animal Animal { get; set; }

        public int AnimalId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DateTime Date { get; set; }

        public Manipulaton()
        {
            InitDate();
        }

        public Manipulaton(EManipulation manipulation)
        {
            InitObjct(manipulation);
            InitDate();
        }

        private void InitDate()
        {
            if (chekIntZero(Year) && chekIntZero(Mounth) && chekIntZero(Day))
            {
                Date = new DateTime(Year, Mounth, Day);
            }
        }

       protected virtual void InitObjct(EManipulation manipulation)
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
