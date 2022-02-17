using Digital_Pet_Passport.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Животоное
    /// </summary>
    public class Animal : IContext, INotifyPropertyChanged
    {
        private int age;
        private string outAge;
        private double weightValue;
        private bool sex;
        private string castration;
        private string kind;
        private string breed;
        private int weight;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        /// <summary>
        /// Порода
        /// </summary>
        public string Breed { get => breed; set { breed = value; OnPropertyChanged("Breed"); } }
        /// <summary>
        /// Вид
        /// </summary>
        public string Kind { get => kind; set { kind = value; OnPropertyChanged("King"); } }
        /// <summary>
        /// Возраст питомца в днях
        /// </summary>
        public int Age
        {
            get => age; set
            {

                age = value;
                OnPropertyChanged("Age");

            }
        }
        /// <summary>
        /// Вес животного
        /// </summary>
        public double WeightValue { get => weightValue; set { weightValue = value; OnPropertyChanged("Weight"); } }
        /// <summary>
        /// Определяет пол животного False - кабель, True - сука
        /// </summary>
        public bool Sex { get => sex; set { sex = value; OnPropertyChanged("Sex"); } }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public BirthDay BirthDay { get; set; }

        public string Castration { get => castration; set { castration = value; OnPropertyChanged("Castration"); } }

        public List<Manipulaton> Manipulatons { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Weight> HistoryWeight { get; set; }

        public int LastWeightId { get => weight; set { weight = value; OnPropertyChanged(nameof(LastWeightId)); } }

        [NotMapped]
        public string OutAge
        {
            get { return outAge; }
            set
            {

                outAge = value;
                OnPropertyChanged("OutAge");

            }
        }
        public Animal()
        {
            //if (age != 0) SetOutAgeAsync();
            //else
            //{
            //    if (BirthDay != null) ReCalculateAge();
            //    else
            //    {
            //        BirthDay = new BirthDay();
            //    }
            //}
            BirthDay = new BirthDay();
            HistoryWeight = new System.Collections.ObjectModel.ObservableCollection<Weight>();
            

        }




        async void SetOutAgeAsync()
        {

            await System.Threading.Tasks.Task.Run(() =>
            {
                int days = age;
                int count = 0;
                int birth = BirthDay.Mounth;
                int year = BirthDay.Year;
                int yearout = 0;

                while (true)
                {
                    if (birth == 13)
                    {
                        birth = 1;
                    }
                    int daystomounththis = DateTime.DaysInMonth(year, birth);

                    days -= daystomounththis;
                    if (days >= 0)
                    {
                        if (count < 12)
                        {
                            count++;

                        }
                        else
                        {
                            count = 1;
                            yearout++;
                            year++;
                        }

                        birth++;
                    }
                    else
                    {
                        days += daystomounththis;
                        break;
                    }
                }

                OutAge = $"{yearout} г.{count} м.{Math.Abs(days)} дн.";

            });


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
            if (BirthDay != null)
            {
                TimeSpan timeSpan = TimeSpan.Zero;
                DateTime birthday = BirthDay.GetBirthDay();
                timeSpan = DateTime.Now.Date - birthday.Date;
                age = ((int)timeSpan.TotalDays);
                SetOutAgeAsync();
            }


        }

        protected void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}
